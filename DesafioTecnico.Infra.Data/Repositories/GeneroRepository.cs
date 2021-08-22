using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Domain.Repositories;
using DesafioTecnico.Infra.Data.Abstraction;
using DesafioTecnico.Infra.Data.Context;

namespace DesafioTecnico.Infrastructure.Data.Repositories
{
  public class GeneroRepository : Repository<Genero>, IGeneroRepository
  {
       public GeneroRepository(DesafioTecnicoDbContext context) : base(context)
       {
       }
  }
}
