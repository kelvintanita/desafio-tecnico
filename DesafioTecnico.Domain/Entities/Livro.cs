using DesafioTecnico.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Domain.Entities
{
    public class Livro : IEntity
    {
        public int Id { get; set; }
        public Guid CodigoLivro { get; set; }
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Descricao { get; set; }
        public string Sinopse { get; set; }
        public string Imagem { get; set; }
        public string Links { get; set; }

        public Genero Generos { get; set; }
    }
}
