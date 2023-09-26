using Newshore.Business.Exceptions;
using Newshore.Business.Interfaces;
using Newshore.Business.Models;
using Newshore.DataAccess.Enums;
using Newshore.DataAccess.Interfaces;

namespace Newshore.Business.Managers
{
    public class FlightManager : IFlightManager
    {
        private readonly INewshoreAPI _newshoreAPI;
        public FlightManager(INewshoreAPI newshoreAPI)
        {
            _newshoreAPI = newshoreAPI;
        }

        public async Task<Journey> GetJourneyAsync(string origin, string destination)
        {
            var result = await _newshoreAPI.GetFlightsAsync(RouteType.Unique);
            var flights = result.Where(x => x.DepartureStation == origin && x.ArrivalStation == destination).ToList();

            if (flights == null || !flights.Any())
            {
                throw new BusinessException("Your query cannot be processed");
            }

            var journey = new Journey();
            journey.Origin = origin;
            journey.Destination = destination;
            journey.Flights = flights.ConvertAll(x => new Flight
            {
                 Destination = x.ArrivalStation,
                 Origin = x.DepartureStation,
                 Price = x.Price,
                 Transport = new Transport
                 {
                     FlightCarrier = x.FlightCarrier,
                     FlightNumber = x.FlightNumber,
                 }
            });
            journey.Price = flights.Sum(x => x.Price);

            return journey;
        }
    }
}
