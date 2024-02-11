using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBBoilerplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PrivateController : ControllerBase
    {

        public PrivateController()
        {
           
        }

        
        [HttpGet("Check")]
        public async Task<IActionResult> Check()
        {
            return Ok("Valid Token");
        }
    }
}