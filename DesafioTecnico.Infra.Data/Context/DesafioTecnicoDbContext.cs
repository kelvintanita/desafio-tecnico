using DbUp;
using DesafioTecnico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DesafioTecnico.Infrastructure.Data;

namespace DesafioTecnico.Infra.Data.Context
{
    public class DesafioTecnicoDbContext : DbContext, IUnitOfWork
    {
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }


        public DesafioTecnicoDbContext(DbContextOptions<DesafioTecnicoDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ad Configurations.Add(new EstadoMap());
        //    modelBuilder.Configurations.Add(new CidadeMap());
        //    modelBuilder.Configurations.Add(new PaisMap());

        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.ApplyMappings(Assembly.GetExecutingAssembly(),
                "DesafioTecnico.Infra.Data.Mappings");

        public void Commit() => SaveChanges();

        public Task CommitAsync() => SaveChangesAsync(true);
    }
}
