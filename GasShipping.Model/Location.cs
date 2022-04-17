namespace GasShipping.Model;

/// <summary>Location Coordinates Class</summary>
public class Location
{
    /// <summary>Gets or sets the x.</summary>
    /// <value>The x.</value>
    public int X { get;  set; }
    /// <summary>Gets or sets the y.</summary>
    /// <value>The y.</value>
    public int Y { get;  set;}

    /// <summary>Initializes a new instance of the <see cref="Location" /> class.
    /// Throws ArgumentNullException if param(s) are null.</summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public Location(int x, int y)
    {
        ArgumentNullException.ThrowIfNull(x, nameof(x));  
        ArgumentNullException.ThrowIfNull(y, nameof(y));
        X = x;
        Y = y;
    }
}