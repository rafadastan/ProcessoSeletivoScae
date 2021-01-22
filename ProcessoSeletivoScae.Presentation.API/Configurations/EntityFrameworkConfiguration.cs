using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProcessoSeletivoScae.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoScae.Presentation.API.Configurations
{
    public class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(IServiceCollection services)
        {
            //configurando a classe SqlContext do projeto Infra.Data
            services.AddDbContext<SqlContext>
                (options => options.UseInMemoryDatabase("BDScae"));
        }
    }
}
