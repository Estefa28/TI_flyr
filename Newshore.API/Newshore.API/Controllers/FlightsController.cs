using Microsoft.AspNetCore.Mvc;
using Newshore.API.Models.Requests;
using Newshore.Business.Interfaces;
using Newshore.Domain.Models;

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
        public async Task<ActionResult<Journey>> GetJourneyAsync([FromQuery] GetJourneyRequest request)
        {
            var result = await _flightManager.GetJourneyAsync(request.Origin.ToUpper(), request.Destination.ToUpper());
            return Ok(result);
        }
    }
}
