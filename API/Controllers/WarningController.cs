using Microsoft.AspNetCore.Mvc;
using WarningModule.Services.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class WarningController(IWarningService warningService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var warning = await warningService.GetWarningAsync(id);
        return Ok(warning);
    }
}