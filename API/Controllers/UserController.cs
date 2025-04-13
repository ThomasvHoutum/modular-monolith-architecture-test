using Microsoft.AspNetCore.Mvc;
using UserFeature.Services.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await userService.GetUserAsync(id);
        
        return Ok(user);
    }
}