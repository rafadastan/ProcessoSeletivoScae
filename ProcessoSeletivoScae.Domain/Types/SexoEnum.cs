using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProcessoSeletivoScae.Domain.Types
{
    public enum SexoEnum
    {
        [Description("Feminino")]
        Feminino = 'F',

        [Description("Masculino")]
        Masculino = 'M'
    }
}
