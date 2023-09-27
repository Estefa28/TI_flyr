using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newshore.Domain.Models;
using Newshore.EF.Constants;

namespace Newshore.EF.Configurations
{
    public class JourneyConfig : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> entity)
        {
            entity.ToTable(nameof(Journey), ConfigConstants.Schema);
        }
    }
}
