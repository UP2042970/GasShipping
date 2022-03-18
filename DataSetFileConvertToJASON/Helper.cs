using GasShipping.Model;
using GasShipping.DataAgent;


internal class Helper
{
    private static List<Customers> _customers;
    private static List<Ship> _ships;
    private static CustomerFactory _customerFactory;
    private static ShipsFactory _shipsFactory;
    private static string dirctory ;

    public static void print(string msg)
    {
        Console.WriteLine(msg);
    }
    public static void run()
    {
        _customerFactory = new CustomerFactory();
        _shipsFactory = new ShipsFactory();
        _customers = new List<Customers>();
        _ships = new List<Ship>();
        dirctory =  @"C:\Users\binma\source\repos\GasShipping\Datasets\";
        var fileagent = new FileAgent("c50.txt", dirctory);
        var fileString = fileagent.ReadFile();
        //print(fileString);
        var lines = fileString.Split(Environment.NewLine);
        //print(lines[0]);
        var numberOfCustomer = 0;
        Int32.TryParse( lines[0].Split(' ')[0],out numberOfCustomer) ;
        numberOfCustomer--;
        //print(numberOfCustomer+"");

         CreateShips(lines[1],lines[2]);
        
    }

    private static void CreateShips(string capacity,string homeLocation)
    {
        var x = 0;
        var y = 0;
        var cap = 0;
        Int32.TryParse(capacity, out cap);
        Int32.TryParse(homeLocation.Split(' ')[0], out x);
        Int32.TryParse(homeLocation.Split(' ')[1], out y);
        for (int i = 0; i < 6; i++)
        {
            _ships.Add( new Ship((i + 1), "Ship_" + (i + 1), new Location(x, y), cap, cap));
        }
    }
}

