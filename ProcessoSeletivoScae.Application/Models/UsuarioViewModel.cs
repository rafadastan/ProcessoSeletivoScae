using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProcessoSeletivoScae.Application.Models
{
    [DisplayColumn("Entrada de usuário")]
    public class UsuarioViewModel
    {
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Senha { get; set; }
    }
}
