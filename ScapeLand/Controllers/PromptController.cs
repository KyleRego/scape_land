using Microsoft.AspNetCore.Mvc;
using ScapeLand.Dtos;
using ScapeLand.Entity;
using ScapeLand.Services;

namespace ScapeLand.Controllers;

public class PromptController(IPromptService promptService) : AppControllerBase
{
    private readonly IPromptService _prmptService = promptService;

    [HttpGet]
    public async Task<ActionResult<PromptDto>> Index()
    {
        return await _prmptService.InitPrompt();
    }
}
