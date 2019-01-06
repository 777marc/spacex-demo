using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using spacex_pads.Models;
using spacex_pads.Services;

namespace spacex_pads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchPadsController : ControllerBase
    {
        private readonly ILaunchPads _repo;
        private readonly ILogger<LaunchPadsController> _logger;
        public LaunchPadsController(ILaunchPads repo, ILogger<LaunchPadsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllPads()
        {
            var launchPads = await _repo.GetAllPads();
            _logger.LogInformation("LaunchPadsController.GetAllPads");
            return Ok(launchPads);
        }
        
        [HttpGet("{padId}")]
        public async Task<IActionResult> Get(string padId)
        {
            var launchPad = await _repo.GetPad(padId);
            _logger.LogInformation("LaunchPadsController.Get");
            return Ok(launchPad);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var launchPads = await _repo.GetPadsByStatus(status);
            _logger.LogInformation("LaunchPadsController.GetPadsByStatus");
            return Ok(launchPads);
        }

        [HttpGet("search/{criteria}")]
        public async Task<IActionResult> GetPadsSearch(string criteria)
        {
            var launchPads = await _repo.GetPadsSearch(criteria);
            _logger.LogInformation("LaunchPadsController.GetPadsSearch");
            return Ok(launchPads);
        }

    }
}
