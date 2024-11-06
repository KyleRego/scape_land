namespace ScapeLand.Entity;

public interface IEntityBase
{
    public string Id { get; set; }
}

public abstract class EntityBase : IEntityBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
