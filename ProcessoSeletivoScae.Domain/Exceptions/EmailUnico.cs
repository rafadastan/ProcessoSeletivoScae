using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Domain.Exceptions
{
    public class EmailUnico : Exception
    {
        private readonly string email;

        public EmailUnico(string email)
        {
            this.email = email;
        }

        public override string Message => $"O Email informado '{email}' Já encontra-se cadastrado. Tente Outro.";
    }
}
