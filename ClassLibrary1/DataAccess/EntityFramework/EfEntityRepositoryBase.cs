using CoreLayer.DataAccess;
using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()
        where TContext : DbContext,new()
    {
        public int Delete(TEntity p)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(TEntity p)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(p);
                addedEntity.State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public List<TEntity> List()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public int Update(TEntity p)
        {
            throw new NotImplementedException();
        }
    }
}
