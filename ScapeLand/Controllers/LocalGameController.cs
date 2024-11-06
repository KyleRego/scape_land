using Microsoft.AspNetCore.Mvc;
using ScapeLand.Model;

namespace ScapeLand.Controllers;

public class LocalGameController(GameState gameState,
                    ILogger<LocalGameController> logger) : AppControllerBase
{
    private readonly GameState _gameState = gameState;
    private readonly ILogger<LocalGameController> _logger = logger;

    [HttpGet]
    public ActionResult<Dictionary<string, GameEntity>>
                                                Show(int xCoord, int yCoord)
    {
        string log = $"showing local game around x: {xCoord}, y: {yCoord}";
        _logger.LogInformation("{Message}", log);
        Vector gamePosition = new(xCoord, yCoord);
        return _gameState.Local(gamePosition);
    }
}
