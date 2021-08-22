using System;
using DesafioTecnico.Domain.Abstractions;
using DesafioTecnico.Domain.Entities;

namespace DesafioTecnico.Application.ViewModels
{
    public class LivroViewModel : LivroCreateEditViewModel
    {
        public int Id { get; set; }
    }
    public class LivroCreateEditViewModel
    {
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
    }
}
