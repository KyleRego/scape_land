using Microsoft.AspNetCore.Mvc;
using ScapeLand.Dtos;
using ScapeLand.Entity;
using ScapeLand.Model;
using ScapeLand.Services;

namespace ScapeLand.Controllers;

public class OptionController(IOptionService service) : AppControllerBase
{
    private readonly IOptionService _optionService = service;

    [HttpPost("{optionId}")]
    public async Task<ActionResult<OptionResultDto>> Post(string optionId,
                                            IPromptService promptService)
    {
        OptionResultNtt optionResult = await _optionService.GetOptionResult(optionId);
        ResultType resultType = optionResult.ResultType;
        string resultId = optionResult.ResultId;

        switch (resultType)
        {
            case ResultType.GoToNextPrompt:
                PromptDto prompt = await promptService.Get(resultId);
                return new OptionResultDto(ResultType.GoToNextPrompt, prompt.Id);
            default:
                return UnprocessableEntity();
        }
    }
}
