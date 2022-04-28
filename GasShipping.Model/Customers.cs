namespace GasShipping.Model;

/// <summary>Customers Data Model</summary>
public class Customers 
{


    /// <summary>Gets the identifier.</summary>
    /// <value>The identifier.</value>
    public int Id { get; init; }

    /// <summary>Gets the name.</summary>
    /// <value>The name.</value>
    public string Name { get; init; }

    /// <summary>Gets the location.</summary>
    /// <value>The location.</value>
    public Location Location { get; init; }
    /// <summary>Gets or sets the type of the customer.</summary>
    /// <value>The type of the customer.</value>
    public int CustomerType { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    /// <value>The quantity.</value>
    public double Quantity { get; set; }

    /// <summary>Initializes a new instance of the <see cref="Customers" /> class.
    /// Throws ArgumentNullException if param(s) are null.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="location">The location.</param>
    /// <param name="customerType">Type of the customer.</param>
    /// <param name="quantity">The quantity.</param>
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

