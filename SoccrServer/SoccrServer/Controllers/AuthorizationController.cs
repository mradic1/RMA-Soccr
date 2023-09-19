using Microsoft.AspNetCore.Mvc;
using SoccrServer.Services;
using System.Net;

namespace SoccrServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly AuthorizationService _authorizationService;
        public AuthorizationController(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            return Ok(_authorizationService.Authorize(username, password));
        }
    }
}
