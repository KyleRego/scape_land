namespace ScapeLand.Model;

public struct Vector
{
    private readonly static Random _rnd = new(); 
    private readonly static int _xMaximum = 100;
    private readonly static int _yMaximum = _xMaximum;

    public int X { get; set; }
    public int Y { get; set; }

    public static Vector Random()
    {
        return new()
        {
            X = _rnd.Next(_xMaximum),
            Y = _rnd.Next(_yMaximum)
        };
    }
}
