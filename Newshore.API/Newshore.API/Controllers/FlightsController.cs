using Microsoft.AspNetCore.Mvc;
using Newshore.Business.Interfaces;
using Newshore.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Newshore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightManager _flightManager;

        public FlightsController(IFlightManager flightManager)
        {
            _flightManager = flightManager;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<Journey>> GetJourneyAsync([Required]string origin = "MZL", [Required]string destination = "MDE")
        {
            var result = await _flightManager.GetJourneyAsync(origin, destination);
            return Ok(result);
        }
    }
}
