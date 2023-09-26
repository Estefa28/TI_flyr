using Microsoft.AspNetCore.Mvc;
using Newshore.Business.Interfaces;
using Newshore.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Newshore.API.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightManager _flightManager;

        public FlightsController(IFlightManager flightManager)
        {
            _flightManager = flightManager;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<Journey>> GetJourneyAsync([Required]string origin, [Required]string destination)
        {
            var result = await _flightManager.GetJourneyAsync(origin, destination);
            return Ok(result);
        }
    }
}
