namespace ScapeLand.Entity;

public class OptionNtt(string nextPromptId, 
                                string text,
                                string warning) : NttBase
{
    public string NextPromptId { get; set; } = nextPromptId;
    public string Text { get; set; } = text;
    public string Warning { get; set; } = warning;

    public List<OptionResultNtt> Results = [];
}
