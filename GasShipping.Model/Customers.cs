namespace GasShipping.Model;

public class Customers 
{
    

    public int Id { get; init; }
    public string Name { get; init; }
    public Location Location { get; init; }
    public int CustomerType { get; set; }

    public double Quantity { get; set; }

    public Customers(int id, string name, Location location, int customerType, double quantity)
    {
        Id = id;
        Name = name;
        Location = location;
        CustomerType = customerType;
        Quantity = quantity;
    }
}

