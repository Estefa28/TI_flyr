using Newshore.EF.Entities;
using Newshore.EF.Interfaces;

namespace Newshore.EF.Repositories
{
    public class SearchRegistryRepository : Repository<SearchRegistry>, ISearchRegistryRepository
    {
        public SearchRegistryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
