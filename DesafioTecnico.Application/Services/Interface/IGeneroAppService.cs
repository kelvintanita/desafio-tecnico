using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioTecnico.Application.ViewModels; 

namespace DesafioTecnico.Application.Interface
{
  public interface IGeneroAppService : IDisposable
  {
    Task<GeneroViewModel> ObterPorIdAsync(int id);
    Task<List<GeneroViewModel>> ObterTodosAsync();
    Task<GeneroViewModel> InserirAsync(GeneroCreateEditViewModel entidade);
    Task<GeneroViewModel> AlterarAsync(int id, GeneroCreateEditViewModel entidade);
    Task ExcluirAsync(int id);
  }
}
