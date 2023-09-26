using Newtonsoft.Json;

namespace Newshore.Domain.Models
{
    public class FlightRecord
    {
        [JsonProperty("departureStation")]
        public string DepartureStation { get; set; }

        [JsonProperty("arrivalStation")]
        public string ArrivalStation { get; set; }

        [JsonProperty("flightCarrier")]
        public string FlightCarrier { get; set; }

        [JsonProperty("flightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
