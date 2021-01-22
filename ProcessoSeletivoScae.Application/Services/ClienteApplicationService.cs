using AutoMapper;
using ProcessoSeletivoScae.Application.Contracts;
using ProcessoSeletivoScae.Application.DTOs;
using ProcessoSeletivoScae.Application.Models;
using ProcessoSeletivoScae.Domain.Contracts.Services;
using ProcessoSeletivoScae.Domain.Entites;
using ProcessoSeletivoScae.Domain.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IMapper _mapper;

        public ClienteApplicationService(IClienteDomainService alunoDomainService, IMapper mapper)
        {
            _clienteDomainService = alunoDomainService;
            _mapper = mapper;
        }

        public ClienteDTO Create(ClienteCadastroModel model)
        {
            var aluno = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                Nome = model.Nome,
                DataNascimento = model.DataDeNascimento,
                Email = model.Email,
                Sexo = (SexoEnum)char.Parse(model.Sexo)
            };

            _clienteDomainService.Create(aluno);

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public ClienteDTO Update(ClienteEdicaoModel model)
        {
            var aluno = _clienteDomainService.GetById(model.IdCliente);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            aluno.Nome = model.Nome;
            aluno.DataNascimento = model.DataDeNascimento;
            aluno.Email = model.Email;

            _clienteDomainService.Update(aluno);

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public ClienteDTO Delete(Guid id)
        {
            var aluno = _clienteDomainService.GetById(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            _clienteDomainService.Delete(aluno);

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public List<ClienteDTO> GetAll()
        {
            var result = new List<ClienteDTO>();

            foreach (var item in _clienteDomainService.GetAll())
            {
                result.Add(new ClienteDTO
                {
                    IdCliente = item.IdCliente,
                    DataNascimento = item.DataNascimento,
                    Email = item.Email,
                    Nome = item.Nome,
                    Sexo = item.Sexo.ToString()
                });
            }

            return result;
        }

        public ClienteDTO GetById(Guid id)
        {
            var aluno = _clienteDomainService.GetById(id);

            if (aluno == null)
                return null;

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public void Dispose()
        {
            _clienteDomainService.Dispose();
        }
    }
}
