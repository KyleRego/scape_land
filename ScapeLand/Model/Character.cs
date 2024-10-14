namespace ScapeLand.Model;

public class Character
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public Vector Position { get; set; } = Vector.Random();
}
