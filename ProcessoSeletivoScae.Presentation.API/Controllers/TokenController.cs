using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProcessoSeletivoScae.Application.Models;
using ProcessoSeletivoScae.Presentation.API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoScae.Presentation.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly JwtToken _jwtToken;

        public TokenController(IConfiguration configuration, JwtToken jwtToken)
        {
            _configuration = configuration;
            _jwtToken = jwtToken;
        }

        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public IActionResult RequestToken(UsuarioViewModel usuario)
        {
            if (usuario == null)
                return NotFound("Invalido");

            if (usuario.Nome != _configuration.GetSection("Usuario").Value 
                || usuario.Senha != _configuration.GetSection("Senha").Value)
            {
                return Unauthorized();
            }
            return StatusCode(200, new
            {
                AccessToken = new
                {
                    BearerToken = _jwtToken.GenerateToken(usuario.Nome),
                    Expiration = DateTime.Now.AddDays(1)
                }
            });
        }
    }
}
