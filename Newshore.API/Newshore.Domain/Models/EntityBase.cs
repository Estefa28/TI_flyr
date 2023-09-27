using System.ComponentModel.DataAnnotations;

namespace Newshore.Domain.Models
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
