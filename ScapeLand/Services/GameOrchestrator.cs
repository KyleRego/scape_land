using ScapeLand.Model;

namespace ScapeLand.Services;

public class GameOrchestrator(  GameState gameState,
                                ILogger<GameOrchestrator> logger)
                                                     : BackgroundService
{
    private readonly GameState _gameState = gameState;
    private readonly ILogger<GameOrchestrator> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            UpdateGameState();
            await Task.Delay(2000, stoppingToken);
        }
    }

    private static void UpdateGameState()
    {
        return;
    }
}
