﻿using CoreLayer.DataAccess;
using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IEntityRepository<T> where T : class,IEntity,new()
    {
        LocalContext context = new LocalContext();
        DbSet<T> _object;
        public Repository()
        {
            _object = context.Set<T>();
        }
        public int Delete(T p)
        {
            _object.Remove(p);
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public int Update(T p)
        {
            return context.SaveChanges();
        }
    }
}
