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
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
    }
}
