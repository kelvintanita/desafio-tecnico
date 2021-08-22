using System.Threading.Tasks;

namespace DesafioTecnico.Infrastructure.Data
{
    public interface IUnitOfWorkBase
    {
        void Commit();
        Task CommitAsync();
    }
}
