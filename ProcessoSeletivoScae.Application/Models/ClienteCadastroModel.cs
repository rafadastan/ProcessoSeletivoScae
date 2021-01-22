﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProcessoSeletivoScae.Application.Models
{
    public class ClienteCadastroModel
    {
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do Cliente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do Cliente.")]
        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        public string Email { get; set; }

        [MinLength(1, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(1, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do Cliente.")]
        public string Sexo { get; set; }
    }
}
