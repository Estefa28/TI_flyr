using Newshore.Business.Exceptions;
using Newshore.Business.Interfaces;
using Newshore.Domain.Models;
using Newshore.DataAccess.Enums;
using Newshore.DataAccess.Interfaces;
using Newshore.EF.Interfaces;
using Newshore.EF.Entities;
using Newtonsoft.Json;
using Newshore.DataAccess.Models;

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

        public async Task<Journey> GetJourneyAsync(string origin, string destination, bool isRoundTrip)
        {
            var cacheData = _searchRegistryRepository.Filter(x => x.Origin == origin && x.Destination == destination && x.IsRoundTrip == isRoundTrip);
            if (cacheData.Any())
            {
                SearchRegistry data = cacheData.First();
                var convertedData = JsonConvert.DeserializeObject<Journey>(data.Content);
                convertedData.IsCache = true;
                convertedData.CacheDate = data.RegistryDate;
                return convertedData;
            }

            var flights = new List<FlightRecord>();
            var result = await _newshoreAPI.GetFlightsAsync(RouteType.MultipleAndReturn);
            var departureFlights = result.Where(x => x.DepartureStation == origin && x.ArrivalStation == destination).ToList();
            if (departureFlights == null || !departureFlights.Any())
            {
                throw new BusinessException("Your query cannot be processed");
            }
            flights.AddRange(departureFlights);
            
            if (isRoundTrip)
            {
                var arrivalFlights = result.Where(x => x.DepartureStation == destination && x.ArrivalStation == origin).ToList();
                if (arrivalFlights == null || !arrivalFlights.Any())
                {
                    throw new BusinessException("Your query cannot be processed");
                }
                flights.AddRange(arrivalFlights);
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
            registry.IsRoundTrip = isRoundTrip;

            _searchRegistryRepository.Add(registry);
            _searchRegistryRepository.Complete();

            return journey;
        }
    }
}
