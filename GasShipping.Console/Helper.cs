using GasShipping.DataAgent;
using GasShipping.FleetRoutingModel;
using GasShipping.Model;
using System.Configuration;

/// <summary>This will be the main class that will be running
/// the Demo</summary>
public static class Helper
{

    /// <summary>Gets or sets the ships.</summary>
    /// <value>The ships.</value>
    public static List<Ship>? Ships { get; set; }

    /// <summary>Gets or sets the ports.</summary>
    /// <value>The ports.</value>
    public static List<Customers>? Ports { get; set; }

    /// <summary>Gets or sets the file agent.</summary>
    /// <value>The file agent.</value>
    public static FileAgent? FileAgent { get; set; }

    /// <summary>Gets or sets the fleet.</summary>
    /// <value>The fleet.</value>
    static Fleet? Fleet { get; set; }

    /// <summary>This is the main method that will run the whole program</summary>
    public static void Run()
    {
        //TODO: call (METHOD)  ask user for file options then populate depending on the option
        // we will use the constant files for now
        Intro();
        int option = Console.ReadLine().ReadInt();
        "".Println();
        var (custFile, shipFile, desc) = GetFilename(option);

        ReadFiles(custFile, shipFile);
        int[,] locationArray;
        long[] loadsArray, ShipCpacitys;
        DataSetup(out locationArray, out loadsArray, out ShipCpacitys);
        var exeTimeinSec = ConfigurationManager.AppSettings.Get("ExcutionTimeInSec").ToString().ReadInt();
        exeTimeinSec= exeTimeinSec==0 ? 1 : exeTimeinSec;
        Fleet = new Fleet(loadsArray, ShipCpacitys, Ships.Count, 0, locationArray);
        FleetRouting fleetRouting = new FleetRouting();
        fleetRouting.Setup(Fleet,calculationTime:exeTimeinSec);
        fleetRouting.PrintSolution(Fleet, fleetRouting.Routing, fleetRouting.Manager, fleetRouting.Solution, desc).Println();



    }

    private static void DataSetup(out int[,] locationArray, out long[] loadsArray, out long[] ShipCpacitys)
    {

        //get the locations and insert them into a list
        List<Location> locations = new List<Location>();
        if (Ships is not null)
        {
            // we add the Home depo location to the list of locations
            locations.Add(Ships[0].Location);
        }
        foreach (var port in Ports)
        {
            locations.Add(port.Location);
        }
        locationArray = ConvertLocationToArray(locations);
        var loads = new List<int>();
        loads.Add(0);//Home load requirements
        loads.AddRange(Ports.Select(p => (int)p.Quantity));

        // Ships.RemoveAt(0);
        loadsArray = loads.ConvertAll(p => Convert.ToInt64(p)).ToArray();
        ShipCpacitys = Ships.Select(p => Convert.ToInt64(p.CurrentCapacity)).ToArray();
        // convert to array
        //Ships.Count
    }

    private static void ReadFiles(string? custFile, string? shipFile)
    {
        FileAgent = new(shipFile, Constants.PATH);
        var shipFactory = new ShipsFactory(FileAgent);
        Ships = shipFactory.GetShipsFromFile();

        FileAgent.FileName = custFile;
        var customerFactory = new CustomerFactory(FileAgent);
        Ports = customerFactory.GetCustomersFromFile();
    }

    /// <summary>Converts the location List&lt;Location&gt; to array int[i,2] . where i is the length of the List&lt;Location&gt;</summary>
    /// <param name="locations">The list of locations.</param>
    /// <returns>
    ///   Array int[i,2] . where i is the length of the List&lt;Location&gt;
    /// </returns>
    static int[,] ConvertLocationToArray(List<Location> locations)
    {

        var idxCount = locations.Count;
        int[,] locationList = new int[idxCount, 2];
        //foreach (var location in locations)
        //{
        //    result.Add(new List<List<int>>(){ location.X,location.Y});
        //}

        for (int i = 0; i < idxCount; i++)
        {
            locationList[i, 0] = locations[i].X;
            locationList[i, 1] = locations[i].Y;

        }
        return locationList;
    }

    /// <summary>Prints the locations array.</summary>
    /// <param name="location">The location.</param>
    static void PrintLocationsArray(int[,] location)
    {
        //var temp = ConvertLocationToArray(locations);
        for (int i = 0; i < location.GetLength(0); i++)
        {
            Console.WriteLine($"({location[i, 0]},{location[i, 1]})");
        }
    }

    /// <summary>Gets the filename.</summary>
    /// <param name="number">The number.</param>
    /// <returns>in=1 out=c50,  in=2 out=c75, in=3 out=c100, </returns>
    static (string,string,string) GetFilename(int number)
    {
        switch (number)
        {
            case 1: return (Constants.CUSTOMER_FILE_NAME_C50, Constants.SHIPS_FILE_NAME_C50,"C50");
            case 2: return (Constants.CUSTOMER_FILE_NAME_C75, Constants.SHIPS_FILE_NAME_C75,"C75");
            case 3: return (Constants.CUSTOMER_FILE_NAME_C100, Constants.SHIPS_FILE_NAME_C100,"C100");
            default:
                return (Constants.CUSTOMER_FILE_NAME_C50, Constants.SHIPS_FILE_NAME_C50, "default c50");
               // break;
        }
       
    }
    public static void Intro()
    {
        var str = "please choose one of the following Routing scenarios:\n";
        for (int i = 1; i < 4; i++)
        {
            var (_, _, desc)= GetFilename(i);
            str += i+": File name " + desc+"\n";
        }
        str.Println();
        "option: ".Print();
    }

    #region "extension  methods"
    public static void Println(this string str)
    {
        Console.WriteLine(str);
    }
    public static void Print(this string str)
    {
        Console.Write(str);
    }
    public static int ReadInt(this string str)
    {
        int result ;
        int.TryParse(str, out result);
        return result;
    }
    #endregion

}

