using Google.OrTools.ConstraintSolver;
using Google.Protobuf.WellKnownTypes;

namespace GasShipping.FleetRoutingModel
{
    /// <summary>This class will have the routing math and calculation done here</summary>
    public class FleetRouting
    {
        /// <summary>Gets or sets the solution.</summary>
        /// <value>The solution.</value>
        Assignment Solution { get; set; }
        /// <summary>Gets or sets the manager.</summary>
        /// <value>The manager.</value>
        RoutingIndexManager Manager { get; set; }
        /// <summary>Gets or sets the routing.</summary>
        /// <value>The routing.</value>
        RoutingModel Routing { get; set; }
        /// <summary>Euclidean distance implemented as a callback. It uses an array of
        /// positions and computes the Euclidean distance between the two
        /// positions of two different indices.</summary>
        /// <param name="locations">int[,]</param>
        /// <returns>long[,]</returns>
        public long[,] ComputeEuclideanDistanceMatrix(in int[,] locations)
        {
            // Calculate the distance matrix using Euclidean distance.
            int locationNumber = locations.GetLength(0);
            long[,] distanceMatrix = new long[locationNumber, locationNumber];
            for (int fromNode = 0; fromNode < locationNumber; fromNode++)
            {
                for (int toNode = 0; toNode < locationNumber; toNode++)
                {
                    if (fromNode == toNode)
                        distanceMatrix[fromNode, toNode] = 0;
                    else
                        distanceMatrix[fromNode, toNode] =
                            (long)Math.Sqrt(Math.Pow(locations[toNode, 0] - locations[fromNode, 0], 2) +
                                            Math.Pow(locations[toNode, 1] - locations[fromNode, 1], 2));
                }
            }
            return distanceMatrix;
        }


        /// <summary>Setups the specified fleet.
        /// and Google OrTools solver</summary>
        /// <param name="fleet">The fleet.</param>
        /// <param name="isEuclidean">if set to <c>true</c> [is euclidean].</param>
        public void Setup(Fleet fleet, bool isEuclidean)
        {
            if (!isEuclidean) fleet.DistanceMatrix = ComputeEuclideanDistanceMatrix(fleet.Portlocations);

            // Create Routing Index Manager
            Manager = CreateRoutingIndexManager(fleet);

            // Create Routing Model.
            Routing = CreateRoutingModel(Manager);

            // Create and register a transit callback.
            // [START transit_callback]
            int transitCallbackIndex = Routing.RegisterTransitCallback((long fromIndex, long toIndex) =>
            {
                // Convert from routing variable Index to distance matrix NodeIndex.
                var fromNode = Manager.IndexToNode(fromIndex);
                var toNode = Manager.IndexToNode(toIndex);
                return fleet.DistanceMatrix[fromNode, toNode];
            });
            // [END transit_callback]

            // Define cost of each arc.
            // [START arc_cost]
            Routing.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);
            // [END arc_cost]


            // Add Capacity constraint.
            // [START capacity_constraint]
            int demandCallbackIndex = Routing.RegisterUnaryTransitCallback((long fromIndex) =>
            {
                // Convert from routing variable Index to demand NodeIndex.
                var fromNode = Manager.IndexToNode(fromIndex);
                return fleet.Demands[fromNode];
            });
            Routing.AddDimensionWithVehicleCapacity(demandCallbackIndex, 0, // null capacity slack
                                                    fleet.ShipCapacities, // Ships maximum capacities
                                                    true,                   // start cumul to zero
                                                    "Capacity");
            // [END capacity_constraint]

            // Setting first solution heuristic.
            // [START parameters]
            RoutingSearchParameters searchParameters =
                operations_research_constraint_solver.DefaultRoutingSearchParameters();
            //searchParameters.FirstSolutionStrategy = FirstSolutionStrategy.Types.Value.PathCheapestArc;
            searchParameters.FirstSolutionStrategy = FirstSolutionStrategy.Types.Value.Christofides;
            searchParameters.LocalSearchMetaheuristic = LocalSearchMetaheuristic.Types.Value.GuidedLocalSearch;
            searchParameters.TimeLimit = new Duration { Seconds = 1 };
            // [END parameters]

            // Solve the problem.
            // [START solve]
            Solution = Routing.SolveWithParameters(searchParameters);
            // [END solve]
        }

        /// <summary>Creates the routing model.</summary>
        /// <param name="manager">The manager.</param>
        /// <returns>new Routing model</returns>
        private static RoutingModel CreateRoutingModel(RoutingIndexManager manager)
        {
            // [START routing_model]
            return new RoutingModel(manager);
            // [END routing_model]
        }

        /// <summary>Creates the routing index manager.</summary>
        /// <param name="fleet">The fleet.</param>
        /// <returns>new RoutingIndexManager</returns>
        private static RoutingIndexManager CreateRoutingIndexManager(Fleet fleet)
        {

            // [START index_manager]
            return new RoutingIndexManager(fleet.DistanceMatrix.GetLength(0), fleet.ShipCount, fleet.Depot);
            // [END index_manager]
        }


        /// <summary>Prints the solution.</summary>
        /// <param name="data">The data.</param>
        /// <param name="routing">The routing.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="solution">The solution.</param>
        public static void PrintSolution(in Fleet data, in RoutingModel routing, in RoutingIndexManager manager,
                            in Assignment solution)
        {
            Console.WriteLine($"Objective {solution.ObjectiveValue()}:");

            // Inspect solution.
            long totalDistance = 0;
            long totalLoad = 0;
            for (int i = 0; i < data.ShipCount; ++i)
            {
                Console.WriteLine("Route for Vehicle {0}:", i + 1);
                long routeDistance = 0;
                //long routeLoad = 0;
                long routeLoad = data.ShipCapacities[i];
                var index = routing.Start(i);
                while (routing.IsEnd(index) == false)
                {
                    long nodeIndex = manager.IndexToNode(index);
                    // routeLoad += data.Demands[nodeIndex];
                    routeLoad -= data.Demands[nodeIndex];
                    //Console.Write("{0} Load({1}) -> ", nodeIndex, routeLoad);
                    Console.Write("{0} {1} Load({2}) -> ", data.Demands[nodeIndex] == 0 ? "Start" : "demand(" + data.Demands[nodeIndex] + ")", nodeIndex == 0 ? "Depo" : "Customer" + nodeIndex, routeLoad);
                    var previousIndex = index;
                    index = solution.Value(routing.NextVar(index));
                    routeDistance += routing.GetArcCostForVehicle(previousIndex, index, 0);
                }
                Console.WriteLine("{0}", manager.IndexToNode((int)index));
                Console.WriteLine("Distance of the route: {0}m", routeDistance);
                totalDistance += routeDistance;
                totalLoad += routeLoad;
            }
            Console.WriteLine("Total distance of all routes: {0}m", totalDistance);
            Console.WriteLine("Total load of all routes: {0}m", totalLoad);
        }
    }
}
