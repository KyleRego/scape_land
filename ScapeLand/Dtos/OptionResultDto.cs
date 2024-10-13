using ScapeLand.Model;

namespace ScapeLand.Dtos;

public class OptionResultDto(ResultType resultType, string resultId)
{
    public ResultType ResultType { get; set; } = resultType;
    public string ResultId { get; set; } = resultId;
}
