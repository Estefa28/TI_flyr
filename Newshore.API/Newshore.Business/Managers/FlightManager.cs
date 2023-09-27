using Newshore.Business.Exceptions;
using Newshore.Business.Interfaces;
using Newshore.Domain.Models;
using Newshore.DataAccess.Enums;
using Newshore.DataAccess.Interfaces;
using Newshore.EF.Interfaces;
using Newshore.EF.Entities;
using Newtonsoft.Json;

namespace Newshore.Business.Managers
{
    public class FlightManager : IFlightManager
    {
        private readonly INewshoreAPI _newshoreAPI;
        private readonly ISearchRegistryRepository _searchRegistryRepository;

        public FlightManager(INewshoreAPI newshoreAPI, ISearchRegistryRepository searchRegistryRepository)
        {
            _newshoreAPI = newshoreAPI;
            _searchRegistryRepository = searchRegistryRepository;
        }

        public async Task<Journey> GetJourneyAsync(string origin, string destination)
        {
            var cacheData = _searchRegistryRepository.Filter(x => x.Origin == origin && x.Destination == destination);
            if (cacheData.Any())
            {
                SearchRegistry data = cacheData.First();
                return JsonConvert.DeserializeObject<Journey>(data.Content);
            }

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

            var registry = new SearchRegistry();
            registry.Origin = origin;
            registry.Destination = destination;
            registry.RegistryDate = DateTime.UtcNow;
            registry.Content = JsonConvert.SerializeObject(journey);

            _searchRegistryRepository.Add(registry);
            _searchRegistryRepository.Complete();

            return journey;
        }
    }
}
