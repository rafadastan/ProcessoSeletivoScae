using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoScae.Domain.Contracts.Repositories;
using ProcessoSeletivoScae.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessoSeletivoScae.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        protected BaseRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public virtual void Create(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Added;
            _sqlContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Deleted;
            _sqlContext.SaveChanges();
        }

        public virtual TEntity Get(Func<TEntity, bool> where)
        {
            return _sqlContext
                .Set<TEntity>()
                .FirstOrDefault(where);
        }

        public virtual List<TEntity> GetAll()
        {
            return _sqlContext
                .Set<TEntity>()
                .ToList();
        }

        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            return _sqlContext
                .Set<TEntity>()
                .Where(where)
                .ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _sqlContext
                .Set<TEntity>()
                .Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            _sqlContext.Entry(entity).State = EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        public void Dispose()
        {
            _sqlContext.Dispose();
        }
    }
}
