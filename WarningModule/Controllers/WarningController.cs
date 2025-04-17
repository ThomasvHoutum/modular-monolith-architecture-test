using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WarningModule.Services.Interfaces;

namespace WarningModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarningController
{
    private readonly IWarningService _warningService;
    
    public WarningController(IWarningService warningService)
    {
        _warningService = warningService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Warning?>> Get(int id)
    {
        var warning = await _warningService.GetWarningAsync(id);
        return warning;
    }
}