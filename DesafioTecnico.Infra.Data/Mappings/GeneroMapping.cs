using DesafioTecnico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Infra.Data.Mappings
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> entity)
        {
            entity.ToTable("Genero");

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
