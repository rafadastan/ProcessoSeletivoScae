using ProcessoSeletivoScae.Domain.Contracts.Repositories;
using ProcessoSeletivoScae.Domain.Entites;
using ProcessoSeletivoScae.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Infra.Data.Repositories
{
    public class ClienteRepository 
        : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly SqlContext _sqlContext;

        public ClienteRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
