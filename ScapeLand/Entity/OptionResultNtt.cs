using ScapeLand.Model;

namespace ScapeLand.Entity;

public class OptionResultNtt : NttBase
{
    public OptionResultNtt(string optionId, ResultType resultType, string resultId)
    {
        OptionId = optionId;
        ResultType = resultType;
        ResultId = resultId;
    }

    public OptionResultNtt(string optionId, string resultId)
    {
        OptionId = optionId;
        ResultId = resultId;
    }

    public string OptionId { get; set;}
    public ResultType ResultType { get; set; }
    public string ResultId { get; set; }
}
