namespace ScapeLand.Dtos;

public class MoveRequest
{
    public required string PlayerId { get; set; }
    public float DesiredX { get; set; }
    public float DesiredY { get; set; }
}
