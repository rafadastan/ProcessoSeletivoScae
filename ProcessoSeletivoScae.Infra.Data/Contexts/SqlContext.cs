using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoScae.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Infra.Data.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
