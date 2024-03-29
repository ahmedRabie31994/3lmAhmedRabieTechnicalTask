﻿using AhmedRabieTechnicalTask.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AhmedRabieTechnicalTask.Infra.Data.Repositories
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public TEntity Create(TEntity entity)
        {
            DbSet.Add(entity);
            Db.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression);
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, int pageNumber, int pageSize)
        {
            return DbSet.Where(expression);
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression,string includeProperties="")
        {
            IQueryable<TEntity> query = DbSet;
            if (includeProperties != "")
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.Where(expression);
        }
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
   
}
