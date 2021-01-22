using ProcessoSeletivoScae.Domain.Contracts.Repositories;
using ProcessoSeletivoScae.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Domain.Services
{
    public abstract class BaseDomainService<TEntity> 
        : IBaseDomainService<TEntity> 
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        protected BaseDomainService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Create(TEntity entity)
        {
            _baseRepository.Create(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _baseRepository.Delete(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _baseRepository.Update(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _baseRepository.GetById(id);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
