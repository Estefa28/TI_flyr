
namespace Newshore.Domain.Models
{
    public class Journey: EntityBase
    {
        public List<Flight> Flights { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public bool IsCache { get; set; }
        public DateTime? CacheDate { get; set; }
    }
}
