using CoreL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task DeleteAsync(TEntity p)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(p);
                deletedEntity.State = EntityState.Deleted;
               await context.SaveChangesAsync();
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public Task<TEntity> GetbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(TEntity p)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(p);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public List<TEntity> List()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task UpdateAsync(TEntity p)
        {
            using (TContext context = new TContext())
            {
                var modifiedEntity = context.Entry(p);
                modifiedEntity.State = EntityState.Modified;
               await context.SaveChangesAsync();
            }
        }


        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<IEntity> GetAll(Expression<Func<IEntity, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

    }

}
