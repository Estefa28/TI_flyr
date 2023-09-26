using Newshore.DataAccess.Enums;
using Newshore.DataAccess.Interfaces;
using Newshore.Domain.Models;

namespace Newshore.DataAccess.API
{
    public class NewshoreAPI : INewshoreAPI
    {
        public async Task<List<FlightRecord>> GetFlightsAsync(RouteType routeType)
        {
            return new List<FlightRecord>
            {
                new FlightRecord
                {
                    DepartureStation = "MZL",
                    ArrivalStation = "BCN",
                    Price = 1000,
                    FlightCarrier = "AA",
                    FlightNumber = "123"
                },
                new FlightRecord
                {
                    DepartureStation = "MZL",
                    ArrivalStation = "BCN",
                    Price = 1500,
                    FlightCarrier = "AA",
                    FlightNumber = "001"
                }
            };
        }
    }
}
