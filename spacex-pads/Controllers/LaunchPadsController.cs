using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public LaunchPadsController(ILaunchPads repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllPads()
        {
            var launchPads = await _repo.GetAllPads();
            return Ok(launchPads);
        }
        
        [HttpGet("{padId}")]
        public async Task<IActionResult> Get(string padId)
        {
            var launchPad = await _repo.GetPad(padId);
            return Ok(launchPad);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var launchPads = await _repo.GetPadsByStatus(status);
            return Ok(launchPads);
        }
    }
}
