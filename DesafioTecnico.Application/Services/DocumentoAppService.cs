using AutoMapper;
using DesafioTecnico.Application.Services.Interface;
using DesafioTecnico.Application.ViewModels;
using DesafioTecnico.Domain.Entities;
using DesafioTecnico.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DesafioTecnico.Infrastructure.Data;

namespace DesafioTecnico.Application.Services
{
    public class DocumentoAppService : AppService, IDocumentoAppService
    {
        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoAppService(IDocumentoRepository documentoRepository, IUnitOfWork uow) : base(uow)
        {
            _documentoRepository = documentoRepository;
        }

        public async Task<DocumentoViewModel> AlterarAsync(int id, DocumentoCreateViewModel documento)
        {
            var entity = await _documentoRepository.ObterPorId(id);

            if (entity == null)
                return null;

            Mapper.Map(documento, entity);

            await CommitAsync();
            return Mapper.Map<DocumentoViewModel>(entity);
        }

        public async Task<DocumentoViewModel> AlterarAsync(int id, DocumentoEditViewModel documento)
        {
            var entity = await _documentoRepository.ObterPorId(id);

            if (entity == null)
                return null;

            Mapper.Map(documento, entity);

            await CommitAsync();
            return Mapper.Map<DocumentoViewModel>(entity);
        }

        public void Dispose()
        {
            _documentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task ExcluirAsync(int id)
        {
            await _documentoRepository.Excluir(id);
            await CommitAsync();
        }

        public async Task<DocumentoViewModel> InserirAsync(DocumentoCreateViewModel entidade)
        {
            try
            {
                var documento = Mapper.Map<DocumentoCreateViewModel, Documento>(entidade);
                await _documentoRepository.Inserir(documento);
                await CommitAsync();

                return Mapper.Map<Documento, DocumentoViewModel>(documento);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DocumentoViewModel>> ObterListaOrdenadaAsync()
        {
            return Mapper.Map<List<Documento>, List<DocumentoViewModel>>(await _documentoRepository.ObterListaOrdenada());
        }

        public async Task<DocumentoViewModel> ObterPorIdAsync(int id)
        {
            return Mapper.Map<Documento, DocumentoViewModel>(await _documentoRepository.ObterPorId(id));
        }

        public async Task<List<DocumentoViewModel>> ObterTodosAsync()
        {
            return Mapper.Map<List<Documento>, List<DocumentoViewModel>>(await _documentoRepository.ObterTodos());
        }
    }
}
