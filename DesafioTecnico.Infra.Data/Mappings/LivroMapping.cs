using DesafioTecnico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Infra.Data.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> entity)
        {
            entity.ToTable("Livro");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.CodigoLivro)
                .IsRequired();

            entity.Property(e => e.DataPublicacao)
                .IsRequired();

            entity.Property(e => e.Paginas)
                .IsRequired();

            entity.Property(e => e.Autor)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Editora)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(e => e.Sinopse)
                .HasMaxLength(1000)
                .IsRequired();

            entity.Property(e => e.Descricao)
                .HasMaxLength(2000)
                .IsRequired();

            entity.Property(e => e.Imagem)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.Links)
                .HasMaxLength(4000)
                .IsRequired();


            entity.HasOne(d => d.Generos)
                .WithMany(p => p.Livros)
                .HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_Genero");


        }
    }
}
