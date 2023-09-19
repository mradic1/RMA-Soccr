using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoccrServer.Models;
using SoccrServer.Services;
using System.Net;

namespace SoccrServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayersController : Controller
    {
        private readonly PlayersService _playersService;

        public PlayersController(PlayersService playersService)
        {
            _playersService = playersService;
        }

        [HttpPost]
        public IActionResult Add([FromForm] string playersJson)
        {
            if (!_playersService.Add(playersJson))
            {
                return BadRequest("Invalid JSON provided");
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Clear()
        {
            _playersService.Clear();
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            string playersJson = _playersService.Get();

            if (string.IsNullOrEmpty(playersJson))
            {
                return StatusCode((int)HttpStatusCode.NoContent, "No players in memory");
            }

            return Ok(playersJson);
        }
    }
}
