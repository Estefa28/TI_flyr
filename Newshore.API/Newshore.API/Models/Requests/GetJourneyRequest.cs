using System.ComponentModel.DataAnnotations;

namespace Newshore.API.Models.Requests
{
    public class GetJourneyRequest
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Origin { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Destination { get; set; }
    }
}
