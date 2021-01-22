using ProcessoSeletivoScae.Domain.Contracts.Repositories;
using ProcessoSeletivoScae.Domain.Contracts.Services;
using ProcessoSeletivoScae.Domain.Entites;
using ProcessoSeletivoScae.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Domain.Services
{
    public class ClienteDomainService : BaseDomainService<Cliente>, IClienteDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.AlunoRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public override void Create(Cliente entity)
        {
            if (_unitOfWork.AlunoRepository
                    .Get(a => a.Email.Equals(entity.Email)) != null)
                throw new EmailUnico(entity.Email);

            base.Create(entity);
        }
    }
}
