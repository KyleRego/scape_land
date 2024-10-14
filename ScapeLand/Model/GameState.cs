namespace ScapeLand.Model;

public class GameState
{
    public GameState()
    {
        Characters = [];

        for (int i = 0; i < 10; i += 1)
        {
            Character newChar = new();
            Characters[newChar.Id] = newChar;
        }
    }

    public Dictionary<string, Character> Characters { get; set; }
}
