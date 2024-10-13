namespace ScapeLand.Dtos;

public class OptionDto(string id, string text, string warning)
{
    public string Id { get; set; } = id;
    public string Text { get; set; } = text;
    public string Warning { get; set; } = warning;
}
