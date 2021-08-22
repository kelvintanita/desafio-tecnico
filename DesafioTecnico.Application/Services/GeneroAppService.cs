using AutoMapper;                             
using System;                                 
using System.Collections.Generic;             
using System.Threading.Tasks;                 
using DesafioTecnico.Application.Interface;    
using DesafioTecnico.Application.ViewModels;   
using DesafioTecnico.Domain.Entities;          
using DesafioTecnico.Domain.Repositories;      
using DesafioTecnico.Infrastructure.Data;      

namespace DesafioTecnico.Application.Services
{
  public class GeneroAppService : AppService, IGeneroAppService
  {
       private readonly IGeneroRepository _generoRepository;

       public GeneroAppService(IGeneroRepository generoRepository, IUnitOfWork uow) : base(uow)
       {
          _generoRepository = generoRepository;
       }

       public async Task ExcluirAsync(int id)
       {
         await _generoRepository.Excluir(id);
         await CommitAsync();
       }

       public async Task<GeneroViewModel> InserirAsync(GeneroCreateEditViewModel entidade)
       {
         var genero = Mapper.Map<GeneroCreateEditViewModel, Genero>(entidade);
         await _generoRepository.Inserir(genero);
         await CommitAsync();
         return Mapper.Map<Genero, GeneroViewModel>(genero);
       }

       public async Task<GeneroViewModel> ObterPorIdAsync(int id)
       {
         return Mapper.Map<Genero, GeneroViewModel>(await _generoRepository.ObterPorId(id));
       }

       public async Task<List<GeneroViewModel>> ObterTodosAsync()
       {
          try
          {
              return Mapper.Map<List<Genero>, List<GeneroViewModel>>(await _generoRepository.ObterTodos());
          }
          catch (Exception ex)
          {
              throw ex;
          }
       }

       public async Task<GeneroViewModel> AlterarAsync(int id, GeneroCreateEditViewModel genero)
       {
           var entity = await _generoRepository.ObterPorId(id);
           if (entity == null)
             return null;
           Mapper.Map(genero, entity);
           await CommitAsync();
           return Mapper.Map<GeneroViewModel>(entity);
       }

       public void Dispose()
       {
           _generoRepository.Dispose(); 
           GC.SuppressFinalize(this);
       }
  }
}
