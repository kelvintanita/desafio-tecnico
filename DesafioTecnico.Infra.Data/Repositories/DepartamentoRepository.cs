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
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(DesafioTecnicoDbContext context) : base(context)
        {
        }
    }
}
