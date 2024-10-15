namespace ScapeLand.Model;

public class Tile
{
    public Tile()
    {
        var colors = Enum.GetValues<TileColor>();
        Random rng = new();
        Color = colors[rng.Next(colors.Length)];
    }

    public int XCoord { get; set; }
    public int YCoord { get; set; }
    public TileColor Color { get; set; }
}

public enum TileColor
{
    Red,
    Green,
    Blue
}