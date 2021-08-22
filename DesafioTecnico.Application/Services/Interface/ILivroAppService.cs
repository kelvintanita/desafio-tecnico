using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioTecnico.Application.ViewModels; 

namespace DesafioTecnico.Application.Interface
{
  public interface ILivroAppService : IDisposable
  {
    Task<LivroViewModel> ObterPorIdAsync(int id);
    Task<List<LivroViewModel>> ObterTodosAsync();
    Task<LivroViewModel> InserirAsync(LivroCreateEditViewModel entidade);
    Task<LivroViewModel> AlterarAsync(int id, LivroCreateEditViewModel entidade);
    Task ExcluirAsync(int id);
  }
}
