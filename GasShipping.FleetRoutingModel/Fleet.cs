namespace GasShipping.FleetRoutingModel
{

    /// <summary>This class will house our model that will be used for the calculations</summary>
    public class Fleet
    {
        /// <summary>property to store all the demand sequentially</summary>
        public long[]? Demands { get; set; }
        /// <summary>Gets or sets the ship capacities.</summary>
        /// <value>The ship capacities.</value>
        public long[]? ShipCapacities { get; set; }
        /// <summary>Gets or sets the ship count.</summary>
        /// <value>The ship count.</value>
        public int ShipCount { get; set; }
        /// <summary>Gets or sets the number depot. initial is 0</summary>
        /// <value>The depot.</value>
        public int Depot { get; set; } = 0;
        /// <summary>Gets or sets the port locations.</summary>
        /// <value>The port locations.</value>
        public int[,]? Portlocations { get; set; }
        /// <summary>Gets or sets the distance matrix.</summary>
        /// <value>The distance matrix.</value>
        public long[,]? DistanceMatrix { get; set; }

        /// <summary>Initializes a new instance of the <see cref="Fleet" /> class.</summary>
        /// <param name="demands">The demands.</param>
        /// <param name="shipCapacities">The ship capacities.</param>
        /// <param name="shipCount">The ship count.</param>
        /// <param name="depot">The depot.</param>
        /// <param name="portlocations">The port locations.</param>
        public Fleet(long[] demands, long[] shipCapacities, int shipCount, int depot, int[,] portlocations)
        {
            Demands = demands;
            ShipCapacities = shipCapacities;
            ShipCount = shipCount;
            Depot = depot;
            Portlocations = portlocations;
        }
        
    }

}
