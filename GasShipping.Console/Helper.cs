using GasShipping.DataAgent;
using GasShipping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This willl be the main class that will be runnig
/// the Demo
/// </summary>
    public static class Helper
    {
   
    public static List<Ship>? Ships { get; set; }
    /// <summary>
    /// list of Customers objects
    /// </summary>
    public static List <Customers>? Ports { get; set; }
    /// <summary>
    /// FileAgent object
    /// </summary>
    public static FileAgent? FileAgent { get; set; }



    /// <summary>
    /// This is the main method that will run the whole program
    /// </summary>
    public static void Run()
    {
        //TODO: call (METHOD)  ask user for file options then populate depending on the option
        // we will use the constant files for now

        FileAgent = new (Constants.SHIPS_FILE_NAME, Constants.PATH);
        var shipFactory=new ShipsFactory(FileAgent);
        Ships= shipFactory.GetShipsFromFile();
        Console.WriteLine(shipFactory.SetShipsToJSONString(Ships));


    }

}

