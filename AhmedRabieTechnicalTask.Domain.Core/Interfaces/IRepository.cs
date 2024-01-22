using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Core.Interfaces
{
   public  interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, int pageNumber, int pageSize);
         

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, string includeProperties = "");
    }
}
