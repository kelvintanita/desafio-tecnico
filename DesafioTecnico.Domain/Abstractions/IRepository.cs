using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Domain.Abstractions
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        Task Inserir(TEntity entidade);
        Task Excluir(int id);
    }
}
