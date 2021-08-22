using DesafioTecnico.Domain.Abstractions;
using DesafioTecnico.Domain.Entities;

namespace DesafioTecnico.Application.ViewModels
{
    public class GeneroViewModel : GeneroCreateEditViewModel
    {
        public int Id { get; set; }

    }
    public class GeneroCreateEditViewModel
    {
        public string Nome { get; set; }
    }
}
