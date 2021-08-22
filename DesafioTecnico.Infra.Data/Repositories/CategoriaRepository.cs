using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Domain.Repositories;
using DesafioTecnico.Infra.Data.Abstraction;
using DesafioTecnico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Infra.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DesafioTecnicoDbContext context) : base(context)
        {
        }
    }
}
