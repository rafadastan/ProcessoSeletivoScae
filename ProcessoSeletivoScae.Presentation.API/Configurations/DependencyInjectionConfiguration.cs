using Microsoft.Extensions.DependencyInjection;
using ProcessoSeletivoScae.Application.Contracts;
using ProcessoSeletivoScae.Application.Services;
using ProcessoSeletivoScae.Domain.Contracts.Repositories;
using ProcessoSeletivoScae.Domain.Contracts.Services;
using ProcessoSeletivoScae.Domain.Services;
using ProcessoSeletivoScae.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoScae.Presentation.API.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            #region Application

            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<IClienteDomainService, ClienteDomainService>();

            #endregion

            #region InfraStructure

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion

        }
    }
}
