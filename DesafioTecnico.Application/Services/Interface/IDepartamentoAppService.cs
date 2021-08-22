using DesafioTecnico.Application.Abstraction;
using DesafioTecnico.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Application.Services.Interface
{
    public interface IDepartamentoAppService : IAppService<DepartamentoViewModel, DepartamentoCreateEditViewModel>
    {
    }
}
