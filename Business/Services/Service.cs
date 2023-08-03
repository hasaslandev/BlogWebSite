using CoreL.DataAccess;
using CoreL.Entities;
using DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/*
namespace Business.Services
{
    public class Service<T> : IEntityRepository<T> where T : class
    {
        private readonly IEntityRepository<T> _entityRepository;
        private readonly UnitOfWorks _unitOfWorks;


        public Service(IEntityRepository<T> entityRepository, UnitOfWorks unitOfWorks)
        {
            _entityRepository = entityRepository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entityRepository.AddAsync(entity);
            await _unitOfWorks.CommitAsync();
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<IEntity> GetAll(Expression<Func<IEntity, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<T> GetbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task IEntityRepository<T>.AddAsync(T entiy)
        {
            throw new NotImplementedException();
        }
    }
}
*/