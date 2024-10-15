using Microsoft.AspNetCore.Mvc;
using ScapeLand.Dtos;
using ScapeLand.Model;

namespace ScapeLand.Controllers;

public class GridController(Grid grid) : AppControllerBase
{
    private readonly Grid _grid = grid;

    [HttpGet]
    public ActionResult<LocalGrid> Show(int xCoord, int yCoord)
    {
        return _grid.LocalGridFor(xCoord, yCoord);
    }
}
