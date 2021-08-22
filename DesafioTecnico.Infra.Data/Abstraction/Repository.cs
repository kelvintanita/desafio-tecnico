using DesafioTecnico.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Infra.Data.Abstraction
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
         where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _set = context.Set<TEntity>();
        }

        public async Task Excluir(int id)
        {
            try
            {
                var entity = await _set.FindAsync(id);
                if (entity != null)
                    _set.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Inserir(TEntity entidade)
        {
            await _set.AddAsync(entidade);
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await _set.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _set.ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
