using ScapeLand.Dtos;

namespace ScapeLand.Model;

public class Grid
{
    private readonly static int sideLength = 256;

    public Grid()
    {
        Tile[][] rows = [];

        for (int i = 0; i < sideLength; i += 1)
        {
            Tile[] row = [];

            for (int j = 0; j < sideLength; j += 1)
            {
                Tile tile = new();
                row[j] = tile;
            }
            rows[i] = row;
        }

        Rows = rows;
    }

    public Tile[][] Rows { get; set; }

    public LocalGrid LocalGridFor(int x, int y)
    {
        LocalGrid lg = new()
        {
            Rows = Rows
        };
        return lg;
    }
}