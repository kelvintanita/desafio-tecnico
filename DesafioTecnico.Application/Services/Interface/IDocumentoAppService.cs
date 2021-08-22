using DesafioTecnico.Application.Abstraction;
using DesafioTecnico.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Application.Services.Interface
{
    public interface IDocumentoAppService : IAppService<DocumentoViewModel, DocumentoCreateViewModel>
    {
        Task<List<DocumentoViewModel>> ObterListaOrdenadaAsync();
        Task<DocumentoViewModel> AlterarAsync(int id, DocumentoEditViewModel entidade);
    }
}
