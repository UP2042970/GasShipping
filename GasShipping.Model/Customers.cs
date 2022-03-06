namespace GasShipping.Model;

public class Customers 
{
    
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public Location Location { get; init; }
    public int CustomerType { get; set; }

    public double Quantity { get; set; }
    /// <summary>
    /// Constructor for Customer. Throws ArgumentNullException if param(s) are null 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="location"></param>
    /// <param name="customerType"></param>
    /// <param name="quantity"></param>
    public Customers(int id, string name, Location location, int customerType, double quantity)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        ArgumentNullException.ThrowIfNull(location, nameof(location));
        ArgumentNullException.ThrowIfNull(customerType, nameof(customerType));
        ArgumentNullException.ThrowIfNull(quantity, nameof(quantity));
        Id = id;
        Name = name;
        Location = location;
        CustomerType = customerType;
        Quantity = quantity;
    }
}

