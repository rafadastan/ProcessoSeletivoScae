using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Application.DTOs
{
    public class ClienteDTO
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
    }
}
