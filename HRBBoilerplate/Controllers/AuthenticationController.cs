using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRBBoilerplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInputDto input)
        {

            var result = await _authenticationService.Login(input);
            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterInputDto input)
        {

            var result = await _authenticationService.Register(input);
            return Ok(result);
        }
    }
}