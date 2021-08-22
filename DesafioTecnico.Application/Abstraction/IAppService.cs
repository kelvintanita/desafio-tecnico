using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Application.Abstraction
{
    public interface IAppService<TEntity, TEntityCreateEdit> : IDisposable where TEntity : class
    {
        Task<TEntity> ObterPorIdAsync(int id);
        Task<List<TEntity>> ObterTodosAsync();
        Task<TEntity> InserirAsync(TEntityCreateEdit entidade);
        Task<TEntity> AlterarAsync(int id, TEntityCreateEdit entidade);
        Task ExcluirAsync(int id);
    }
}
