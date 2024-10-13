namespace ScapeLand.Entity;

public class PromptNtt(string text) : NttBase
{
    public bool InitialPrompt { get; set; } = false;
    public string Text { get; set; } = text;
    public List<OptionNtt> Options { get; set; } = [];
}
