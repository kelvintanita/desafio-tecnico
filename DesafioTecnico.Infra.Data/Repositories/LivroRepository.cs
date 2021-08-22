using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Domain.Repositories;
using DesafioTecnico.Infra.Data.Abstraction;
using DesafioTecnico.Infra.Data.Context;

namespace DesafioTecnico.Infrastructure.Data.Repositories
{
  public class LivroRepository : Repository<Livro>, ILivroRepository
  {
       public LivroRepository(DesafioTecnicoDbContext context) : base(context)
       {
       }
  }
}
