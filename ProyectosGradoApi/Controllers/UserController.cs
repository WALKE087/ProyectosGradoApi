using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;
using Shared.LoginDto;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore.Design;
using System.Security.Authentication;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public LoginController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _serviceManager.UserService
                    .LoginAsync(loginDto.Email, loginDto.Password);

                return Ok(new
                {
                    message = "Inicio de sesión exitoso.",
                    user = new
                    {
                        user.Id,
                        user.Name,
                        user.Email
                    }
                });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (InvalidCredentialsException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
