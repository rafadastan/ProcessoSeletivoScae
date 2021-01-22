using Microsoft.EntityFrameworkCore.Storage;
using ProcessoSeletivoScae.Domain.Contracts.Repositories;
using ProcessoSeletivoScae.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IClienteRepository AlunoRepository => new ClienteRepository(_sqlContext);

        public void BeginTransaction()
        {
            _transaction = _sqlContext
                .Database
                .BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _sqlContext.Dispose();
        }
    }
}
