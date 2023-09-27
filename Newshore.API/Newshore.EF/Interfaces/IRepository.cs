using Newshore.EF.Entities;
using System.Linq.Expressions;

namespace Newshore.EF.Interfaces
{
    public interface IRepository<Model> where Model : EntityBase
    {
        IEnumerable<Model> Filter(Expression<Func<Model, bool>> filter = null);
        void Add(Model model);
        int Complete();
    }
}
