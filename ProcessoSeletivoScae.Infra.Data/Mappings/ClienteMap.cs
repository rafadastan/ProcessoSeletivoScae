using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoScae.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoScae.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(a => a.IdCliente);

            builder.Property(a => a.IdCliente)
                .HasColumnName("IdCliente");

            builder.Property(a => a.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("Email")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            builder.Property(a => a.Sexo)
                .HasColumnName("Sexo")
                .IsRequired();
        }
    }
}
