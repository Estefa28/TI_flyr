using Newshore.DataAccess.Enums;
using Newshore.DataAccess.Exceptions;
using Newshore.DataAccess.Interfaces;
using Newshore.DataAccess.Models;
using Newtonsoft.Json;

namespace Newshore.DataAccess.API
{
    public class NewshoreAPI : INewshoreAPI
    {
        const string APIUrl = "https://recruiting-api.newshore.es/api/flights/";

        public async Task<List<FlightRecord>> GetFlightsAsync(RouteType routeType)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{APIUrl}{(int)routeType}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FlightRecord>>(content);
            }

            throw new DataAccessException("No data found");
        }
    }
}
