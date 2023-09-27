using Newshore.DataAccess.Enums;
using Newshore.DataAccess.Interfaces;
using Newshore.DataAccess.Models;
using Newtonsoft.Json;

namespace Newshore.DataAccess.API
{
    public class NewshoreAPI : INewshoreAPI
    {
        public async Task<List<FlightRecord>> GetFlightsAsync(RouteType routeType)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://recruiting-api.newshore.es/api/flights/0");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FlightRecord>>(content);
            }

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
