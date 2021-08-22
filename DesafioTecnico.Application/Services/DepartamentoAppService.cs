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
    public class DepartamentoAppService : AppService, IDepartamentoAppService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoAppService(IDepartamentoRepository departamentoRepository, IUnitOfWork uow) : base(uow)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<DepartamentoViewModel> AlterarAsync(int id, DepartamentoCreateEditViewModel departamento)
        {
            var entity = await _departamentoRepository.ObterPorId(id);

            if (entity == null)
                return null;

            Mapper.Map(departamento, entity);

            await CommitAsync();
            return Mapper.Map<DepartamentoViewModel>(entity);
        }

        public void Dispose()
        {
            _departamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task ExcluirAsync(int id)
        {
            await _departamentoRepository.Excluir(id);
            await CommitAsync();
        }

        public async Task<DepartamentoViewModel> InserirAsync(DepartamentoCreateEditViewModel entidade)
        {
            var departamento = Mapper.Map<DepartamentoCreateEditViewModel, Departamento>(entidade);
            await _departamentoRepository.Inserir(departamento);
            await CommitAsync();

            return Mapper.Map<Departamento, DepartamentoViewModel>(departamento);
        }

        public async Task<DepartamentoViewModel> ObterPorIdAsync(int id)
        {
            return Mapper.Map<Departamento, DepartamentoViewModel>(await _departamentoRepository.ObterPorId(id));
        }

        public async Task<List<DepartamentoViewModel>> ObterTodosAsync()
        {
            return Mapper.Map<List<Departamento>, List<DepartamentoViewModel>>(await _departamentoRepository.ObterTodos());
        }
    }
}
