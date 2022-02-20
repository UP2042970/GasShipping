namespace GasShipping.Model;

public class Location
{
    public int X { get;  set; }
    public int Y { get;  set;}
    /// <summary>
    /// Constructor for Location. Throws ArgumentNullException if param(s) are null 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Location(int x, int y)
    {
        ArgumentNullException.ThrowIfNull(x, nameof(x));  
        ArgumentNullException.ThrowIfNull(y, nameof(y));
        X = x;
        Y = y;
    }
}