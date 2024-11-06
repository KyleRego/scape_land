namespace ScapeLand.Model;

public class GameEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public Vector Position { get; set; } = Vector.Random();
}
