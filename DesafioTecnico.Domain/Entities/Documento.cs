using DesafioTecnico.Domain.Abstractions;
using System;

namespace DesafioTecnico.Domain.Entities
{
    public class Documento 
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public int DepartamentoId { get; set; }
        public int CategoriaId { get; set; }
        public DateTime DataCadastro { get; set; }

        public Departamento Departamento { get; set; }
        public Categoria Categoria { get; set; }
    }
}
