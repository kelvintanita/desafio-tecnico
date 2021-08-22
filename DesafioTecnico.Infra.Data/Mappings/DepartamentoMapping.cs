using DesafioTecnico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Infra.Data.Mappings
{
    public class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> entity)
        {
            entity.ToTable("Departamento");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
