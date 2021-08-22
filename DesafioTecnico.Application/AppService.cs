using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DesafioTecnico.Infrastructure.Data;

namespace DesafioTecnico.Application
{
    public class AppService
    {
        private readonly IUnitOfWorkBase _uow;

        public AppService(IUnitOfWorkBase uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public async Task CommitAsync()
        {
            await _uow.CommitAsync();
        }
    }
}
