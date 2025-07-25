using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;
using Shared.LoginDto;
using System.Threading.Tasks;

namespace Presentation.Controllers.ControllerUser;

[ApiController]
[Route("api/Login")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _serviceManager.UserService.LoginAsync(loginDto.Email, loginDto.Password);
        return Ok(user);
    }
}
