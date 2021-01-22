using ProcessoSeletivoScae.Application.DTOs;
using ProcessoSeletivoScae.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Application.Contracts
{
    public interface IClienteApplicationService : IDisposable
    {
        ClienteDTO Create(ClienteCadastroModel model);
        ClienteDTO Update(ClienteEdicaoModel model);
        ClienteDTO Delete(Guid id);
        List<ClienteDTO> GetAll();
        ClienteDTO GetById(Guid id);
    }
}
