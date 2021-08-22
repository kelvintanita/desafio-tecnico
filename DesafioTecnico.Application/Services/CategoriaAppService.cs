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
    public class CategoriaAppService : AppService, ICategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaAppService(ICategoriaRepository categoriaRepository, IUnitOfWork uow) : base(uow)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaViewModel> AlterarAsync(int id, CategoriaCreateEditViewModel categoria)
        {
            var entity = await _categoriaRepository.ObterPorId(id);

            if (entity == null)
                return null;

            Mapper.Map(categoria, entity);

            await CommitAsync();
            return Mapper.Map<CategoriaViewModel>(entity);
        }

        public void Dispose()
        {
            _categoriaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task ExcluirAsync(int id)
        {
            await _categoriaRepository.Excluir(id);
            await CommitAsync();
        }

        public async Task<CategoriaViewModel> InserirAsync(CategoriaCreateEditViewModel entidade)
        {
            var categoria = Mapper.Map<CategoriaCreateEditViewModel, Categoria>(entidade);
            await _categoriaRepository.Inserir(categoria);
            await CommitAsync();

            return Mapper.Map<Categoria, CategoriaViewModel>(categoria);
        }

        public async Task<CategoriaViewModel> ObterPorIdAsync(int id)
        {
            return Mapper.Map<Categoria, CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));
        }

        public async Task<List<CategoriaViewModel>> ObterTodosAsync()
        {
            return Mapper.Map<List<Categoria>, List<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
        }
    }
}
