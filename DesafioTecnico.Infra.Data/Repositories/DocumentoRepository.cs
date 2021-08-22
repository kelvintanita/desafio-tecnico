using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Domain.Repositories;
using DesafioTecnico.Infra.Data.Abstraction;
using DesafioTecnico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Infra.Data.Repositories
{
    public class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(DesafioTecnicoDbContext context) : base(context)
        {
        }

        public async Task<List<Documento>> ObterListaOrdenada()
        {
            return await _set.OrderBy(s => s.Titulo)
                             .Include(e => e.Categoria)
                             .Include(e => e.Departamento)
                             .ToListAsync();
        }
    }
}
