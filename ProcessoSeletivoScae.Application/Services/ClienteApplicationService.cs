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
        private readonly IClienteDomainService _alunoDomainService;
        private readonly IMapper _mapper;

        public ClienteApplicationService(IClienteDomainService alunoDomainService, IMapper mapper)
        {
            _alunoDomainService = alunoDomainService;
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

            _alunoDomainService.Create(aluno);

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public ClienteDTO Update(ClienteEdicaoModel model)
        {
            var aluno = _alunoDomainService.GetById(model.IdCliente);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            aluno.Nome = model.Nome;
            aluno.DataNascimento = model.DataDeNascimento;
            aluno.Email = model.Email;

            _alunoDomainService.Update(aluno);

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public ClienteDTO Delete(Guid id)
        {
            var aluno = _alunoDomainService.GetById(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            _alunoDomainService.Delete(aluno);

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public List<ClienteDTO> GetAll()
        {
            var result = new List<ClienteDTO>();

            foreach (var item in _alunoDomainService.GetAll())
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
            var aluno = _alunoDomainService.GetById(id);

            if (aluno == null)
                return null;

            var alunoModel = _mapper.Map<ClienteDTO>(aluno);

            return alunoModel;
        }

        public void Dispose()
        {
            _alunoDomainService.Dispose();
        }
    }
}
