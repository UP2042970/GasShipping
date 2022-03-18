using GasShipping.Model;
using GasShipping.DataAgent;


internal class Helper
{
    private static List<Customers> _customers;
    private static List<Ship> _ships;
    private static CustomerFactory _customerFactory;
    private static ShipsFactory _shipsFactory;

    public static void print(string msg)
    {
        Console.WriteLine(msg);
    }
}

