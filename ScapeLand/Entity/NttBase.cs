namespace ScapeLand.Entity;

public interface INtt
{
    public string Id { get; set; }
}

public abstract class NttBase : INtt
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
