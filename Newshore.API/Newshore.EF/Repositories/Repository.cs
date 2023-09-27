using Microsoft.EntityFrameworkCore;
using Newshore.EF.Entities;
using Newshore.EF.Exceptions;
using Newshore.EF.Interfaces;
using System.Linq.Expressions;

namespace Newshore.EF.Repositories
{
    public class Repository<Model> : IRepository<Model> where Model : EntityBase
    {
        private readonly ApplicationContext Context;
        private readonly DbSet<Model> DbSet;

        public Repository(ApplicationContext context)
        {
            Context = context;
            DbSet = context.Set<Model>();
        }

        public virtual void Add(Model model)
        {
            if (model == null)
                throw new EFException($"{nameof(Add)} method requires a model.");

            DbSet.Add(model);
        }

        public virtual IEnumerable<Model> Filter(Expression<Func<Model, bool>> filter = null)
        {
            if (filter == null)
                return DbSet.ToList();

            return Find(filter);
        }

        private IEnumerable<Model> Find(Expression<Func<Model, bool>> filter = null)
        {
            try
            {
                IQueryable<Model> query = DbSet;
                if (filter != null)
                    query = query.Where(filter);

                return query.ToList();
            }
            catch (Exception)
            {
                return new List<Model>();
            }
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }
    }
}
