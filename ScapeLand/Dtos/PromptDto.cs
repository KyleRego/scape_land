namespace ScapeLand.Dtos;

public class PromptDto(string id, string text, List<OptionDto> choices)
{
    public string Id { get; set; } = id;
    public string Text { get; set; } = text;

    public List<OptionDto> Options { get; set; } = choices;
}
