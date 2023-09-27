using System.ComponentModel.DataAnnotations;

namespace Newshore.EF.Entities
{
    public class SearchRegistry: EntityBase
    {
        [Required]
        public DateTime RegistryDate { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [StringLength(3,MinimumLength = 3)]
        public string Origin { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Destination { get; set; }
        [Required]
        public bool IsRoundTrip { get; set; }
    }
}
