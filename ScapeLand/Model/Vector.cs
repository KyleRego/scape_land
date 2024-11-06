namespace ScapeLand.Model;

public struct Vector(int x, int y)
{
    private readonly static Random _rng = new(); 
    private readonly static int _xMaximum = 100;
    private readonly static int _yMaximum = _xMaximum;

    // TODO: Use property setters to prevent
    // this from being greater than maximum coords
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public static Vector Random()
    {
        return new()
        {
            X = _rng.Next(_xMaximum),
            Y = _rng.Next(_yMaximum)
        };
    }

    public readonly double DistanceTo(Vector other)
    {
        int deltaX = Math.Abs(other.X - X);
        int deltaY = Math.Abs(other.Y - Y);
        return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }
}
