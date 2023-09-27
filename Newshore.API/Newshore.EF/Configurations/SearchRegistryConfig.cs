using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newshore.EF.Constants;
using Newshore.EF.Entities;

namespace Newshore.EF.Configurations
{
    public class SearchRegistryConfig: IEntityTypeConfiguration<SearchRegistry>
    {
        public void Configure(EntityTypeBuilder<SearchRegistry> entity)
        {
            entity.ToTable(nameof(SearchRegistry), ConfigConstants.Schema);

            entity.HasIndex(x => x.Origin);
            entity.HasIndex(x => x.Destination);
        }
    }
}
