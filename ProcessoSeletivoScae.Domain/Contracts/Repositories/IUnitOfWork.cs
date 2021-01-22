using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }

        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
