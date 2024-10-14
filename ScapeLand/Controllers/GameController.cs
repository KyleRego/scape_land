using Microsoft.AspNetCore.Mvc;
using ScapeLand.Dtos;
using ScapeLand.Model;

namespace ScapeLand.Controllers;

public class GameController(GameState gameState) : AppControllerBase
{
    private readonly GameState _gameState = gameState;

    [HttpPost("move")]
    public IActionResult MovePlayer(MoveRequest moveRequest)
    {
        return NotFound();
    }

    [HttpGet("state")]
    public ActionResult<GameState> GetGameState()
    {
        return Ok(_gameState);
    }
}
