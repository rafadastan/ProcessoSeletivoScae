using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoScae.Application.Contracts;
using ProcessoSeletivoScae.Application.Models;
using ProcessoSeletivoScae.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoScae.Presentation.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClienteController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(ClienteCadastroModel model)
        {
            try
            {
                var clienteDTO = _clienteApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Cliente cadastrado com sucesso.",
                    Cliente = clienteDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(ClienteEdicaoModel model)
        {
            try
            {
                var clienteDTO = _clienteApplicationService.Update(model);

                return StatusCode(200, new
                {
                    Message = "Aluno atualizado com sucesso.",
                    Cliente = clienteDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var clienteDTO = _clienteApplicationService.Delete(id);

                return StatusCode(200, new
                {
                    Message = "Aluno excluído com sucesso.",
                    Cliente = clienteDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _clienteApplicationService.GetAll();

                if (result == null || result.Count == 0)
                    return StatusCode(204);

                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var alunoDTO = _clienteApplicationService.GetById(id);

                if (alunoDTO == null)
                    return StatusCode(204);

                return StatusCode(200, alunoDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

    }
}
