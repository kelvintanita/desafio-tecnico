using DesafioTecnico.Domain.Abstractions;
using DesafioTecnico.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Domain.Repositories
{
    public interface IDocumentoRepository : IRepository<Documento>
    {
        Task<List<Documento>> ObterListaOrdenada();
    }
}
