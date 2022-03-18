using GasShipping.DataAgent;
using GasShipping.Model;


internal class Helper
{
    private static List<Customers> _customers;
    private static List<Ship> _ships;
    private static CustomerFactory _customerFactory;
    private static ShipsFactory _shipsFactory;
    private static string fromDirctory;
    private static string toDirctory;

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
        fromDirctory = @"C:\Users\binma\source\repos\GasShipping\Datasets\";
        toDirctory = @"C:\Users\binma\source\repos\GasShipping\Datasets\JsonFormat\";
        var fileagent = new FileAgent("c75.txt", fromDirctory);
        var fileString = fileagent.ReadFile();
        var lines = fileString.Split(Environment.NewLine);
        var numberOfCustomer = 0;
        Int32.TryParse(lines[0].Split(' ')[0], out numberOfCustomer);
        CreateShips(lines[1], lines[2]);
        var shipsJSON = _shipsFactory.SetShipsToJSONString(_ships);
        //print(shipsJSON);
        fileagent.DirectoryName = toDirctory;
        //fileagent.FileName = fileagent.FileName.Split('.')[0] + "_ships.json";
        //fileagent.WriteFile(shipsJSON);
        CreateCustomers(numberOfCustomer, lines);
        var customerJSON = _customerFactory.SetCustomersToJSONString(_customers);
        //print(customerJSON);
        fileagent.FileName = fileagent.FileName.Split('.')[0] + "_customers.json";
        fileagent.WriteFile(customerJSON);

    }

    private static void CreateShips(string capacity, string homeLocation)
    {
        var x = 0;
        var y = 0;
        var cap = 0;
        Int32.TryParse(capacity, out cap);
        Int32.TryParse(homeLocation.Split(' ')[0], out x);
        Int32.TryParse(homeLocation.Split(' ')[1], out y);
        for (int i = 0; i < 9; i++)
        {
            _ships.Add(new Ship((i + 1), "Ship_" + (i + 1), new Location(x, y), cap, cap));
        }
    }
    private static void CreateCustomers(int numberOfCustomer, string[] lines)
    {

        var idx = 3;
        numberOfCustomer++;
        for (int i = 1; i < numberOfCustomer; i++)
        {
            var x = 0;
            var y = 0;
            var id = 0;
            var demand = 0;
            var temp = lines[idx].Split(' ');

            Int32.TryParse(temp[1], out id);
            Int32.TryParse(temp[2], out x);
            Int32.TryParse(temp[3], out y);
            Int32.TryParse(temp[4], out demand);
            idx++;
            _customers.Add(new Customers(id, "customer_" + id, new Location(x, y), 0, (double)demand));


        }
    }
}

