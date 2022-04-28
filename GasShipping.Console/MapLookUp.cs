using GasShipping.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
///   <br />
/// </summary>
public class MapLookUp{
    //
    /// <summary>Gets or sets the ship lookup.</summary>
    /// <value>The ship lookup.</value>
    public Dictionary<int, Ship> ShipLookup { get; set; }
    /// <summary>Gets or sets the customer lookup.</summary>
    /// <value>The customer lookup.</value>
    public Dictionary<int, Customers> CustomerLookup { get; set; }

    /// <summary>Adds the ship.</summary>
    /// <param name="key">The key.</param>
    /// <param name="ship">The ship.</param>
    public void AddShip(int key, Ship ship) => ShipLookup.Add(key, ship);
    /// <summary>Removes the ship.</summary>
    /// <param name="key">The key.</param>
    public void RemoveShip(int key) => ShipLookup.Remove(key);
    /// <summary>Adds the customer.</summary>
    /// <param name="key">The key.</param>
    /// <param name="customer">The customer.</param>
    public void AddCustomer(int key,Customers customer) => CustomerLookup.Add(key, customer);
    /// <summary>Removes the customer.</summary>
    /// <param name="key">The key.</param>
    public void RemoveCustomer(int key) => CustomerLookup.Remove(key);

    /// <summary>Initializes a new instance of the <see cref="MapLookUp" /> class.</summary>
    public MapLookUp()
    {
        ShipLookup = new Dictionary<int, Ship>();
        CustomerLookup = new Dictionary<int, Customers>();
    }

    
}

