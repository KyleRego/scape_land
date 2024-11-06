namespace ScapeLand.Model;

public class GameState
{
    public GameState()
    {
        Entities = [];

        for (int i = 0; i < 10; i += 1)
        {
            GameEntity entity = new();
            Entities[entity.Id] = entity;
        }
    }

    public Dictionary<string, GameEntity> Entities { get; set; }

    public Dictionary<string, GameEntity> Local(Vector localPosition)
    {
        Dictionary<string, GameEntity> localEntities = [];

        foreach (GameEntity entity in Entities.Values)
        {
            if (localPosition.DistanceTo(entity.Position) < 40)
            {
                localEntities[entity.Id] = entity;
            }
        }

        return localEntities;
    }
}
