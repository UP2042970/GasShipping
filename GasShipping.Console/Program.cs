// See https://aka.ms/new-console-template for more information
//Helper.Run();

using GasShipping.DataAgent;
using GasShipping.FleetRoutingModel;
using GasShipping.Model;

//Ship ship = new Ship(int.MaxValue , "", new Location(int.MaxValue, 2), double.PositiveInfinity);
//ship.Name.Println();
//ship.Id.ToString().Println();
//ship.Location.X.ToString().Println();
//ship.TotalCapacity.ToString().Println();

//FileAgent fileAgent=new FileAgent("file",null);
//fileAgent.ReadFile();
FleetRouting fleetRouting = new();
//var test=fleetRouting.ComputeEuclideanDistanceMatrix(new int[,] { { int.MaxValue, int.MaxValue }, { int.MaxValue, int.MaxValue } });

//foreach (var item in test)
//{
//    item.ToString().Println();
//}
fleetRouting.PrintSolution(null,null,null,null);


