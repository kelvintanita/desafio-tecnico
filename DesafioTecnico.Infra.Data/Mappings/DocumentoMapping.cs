using DesafioTecnico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Infra.Data.Mappings
{
    public class DocumentoMapping : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> entity)
        {
            entity.ToTable("Documento");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsRequired();

            //entity.HasIndex(e => new
            //{
            //    e.Codigo,
            //}).HasName("IX_CodigoIndex")
            //  .IsUnique();

            //entity.Property(e => e.DepartamentoId)
            //    .IsRequired();

            //entity.Property(e => e.CategoriaId)
            //    .IsRequired();


            entity.HasOne(d => d.Departamento)
                .WithMany(p => p.Documento)
                .HasForeignKey(d => d.DepartamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_Departamento");

            entity.HasOne(d => d.Categoria)
                .WithMany(p => p.Documento)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_Categoria");


        }
    }
}
