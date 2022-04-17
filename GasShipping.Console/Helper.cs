using GasShipping.DataAgent;
using GasShipping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>This will be the main class that will be running
/// the Demo</summary>
public static class Helper
    {

    /// <summary>Gets or sets the ships.</summary>
    /// <value>The ships.</value>
    public static List<Ship>? Ships { get; set; }

    /// <summary>Gets or sets the ports.</summary>
    /// <value>The ports.</value>
    public static List <Customers>? Ports { get; set; }

    /// <summary>Gets or sets the file agent.</summary>
    /// <value>The file agent.</value>
    public static FileAgent? FileAgent { get; set; }



    /// <summary>This is the main method that will run the whole program</summary>
    public static void Run()
    {
        //TODO: call (METHOD)  ask user for file options then populate depending on the option
        // we will use the constant files for now

        FileAgent = new (Constants.SHIPS_FILE_NAME_C50, Constants.PATH);
        var shipFactory=new ShipsFactory(FileAgent);
        Ships= shipFactory.GetShipsFromFile();
        //Console.WriteLine(shipFactory.SetShipsToJSONString(Ships));
        FileAgent.FileName = Constants.CUSTOMER_FILE_NAME_C50;
        var customerFactory=new CustomerFactory(FileAgent);
        Ports=customerFactory.GetCustomersFromFile();
        Console.WriteLine(customerFactory.SetCustomersToJSONString((Ports)));

    }

}

