using Google.OrTools.ConstraintSolver;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasShipping.FleetRoutingModel
{
    /// <summary>This class will have the routing math and calculation done here</summary>
    public class FleetRouting
    {
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
            // [START index_manager]
            RoutingIndexManager manager =
                new RoutingIndexManager(fleet.DistanceMatrix.GetLength(0), fleet.ShipCount, fleet.Depot);
            // [END index_manager]

            // Create Routing Model.
            // [START routing_model]
            RoutingModel routing = new RoutingModel(manager);
            // [END routing_model]

            // Create and register a transit callback.
            // [START transit_callback]
            int transitCallbackIndex = routing.RegisterTransitCallback((long fromIndex, long toIndex) =>
            {
                // Convert from routing variable Index to distance matrix NodeIndex.
                var fromNode = manager.IndexToNode(fromIndex);
                var toNode = manager.IndexToNode(toIndex);
                return fleet.DistanceMatrix[fromNode, toNode];
            });
            // [END transit_callback]

            // Define cost of each arc.
            // [START arc_cost]
            routing.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);
            // [END arc_cost]


            // Add Capacity constraint.
            // [START capacity_constraint]
            int demandCallbackIndex = routing.RegisterUnaryTransitCallback((long fromIndex) =>
            {
                // Convert from routing variable Index to demand NodeIndex.
                var fromNode = manager.IndexToNode(fromIndex);
                return fleet.Demands[fromNode];
            });
            routing.AddDimensionWithVehicleCapacity(demandCallbackIndex, 0, // null capacity slack
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
            Assignment solution = routing.SolveWithParameters(searchParameters);
            // [END solve]
        }
    }
}
