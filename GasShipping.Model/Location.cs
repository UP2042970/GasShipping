namespace GasShipping.Model;

public class Location
{
    public int X { get;  set; }
    public int Y { get;  set;}

    public Location(int x, int y)
    {
        ArgumentNullException.ThrowIfNull(x, nameof(x));  
        ArgumentNullException.ThrowIfNull(y, nameof(y));
        X = x;
        Y = y;
    }
}