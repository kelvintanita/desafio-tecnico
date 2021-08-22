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
  public class LivroAppService : AppService, ILivroAppService
  {
       private readonly ILivroRepository _livroRepository;

       public LivroAppService(ILivroRepository livroRepository, IUnitOfWork uow) : base(uow)
       {
          _livroRepository = livroRepository;
       }

       public async Task ExcluirAsync(int id)
       {
         await _livroRepository.Excluir(id);
         await CommitAsync();
       }

       public async Task<LivroViewModel> InserirAsync(LivroCreateEditViewModel entidade)
       {
         var livro = Mapper.Map<LivroCreateEditViewModel, Livro>(entidade);
         await _livroRepository.Inserir(livro);
         await CommitAsync();
         return Mapper.Map<Livro, LivroViewModel>(livro);
       }

       public async Task<LivroViewModel> ObterPorIdAsync(int id)
       {
         return Mapper.Map<Livro, LivroViewModel>(await _livroRepository.ObterPorId(id));
       }

       public async Task<List<LivroViewModel>> ObterTodosAsync()
       {
          try
          {
              return Mapper.Map<List<Livro>, List<LivroViewModel>>(await _livroRepository.ObterTodos());
          }
          catch (Exception ex)
          {
              throw ex;
          }
       }

       public async Task<LivroViewModel> AlterarAsync(int id, LivroCreateEditViewModel livro)
       {
           var entity = await _livroRepository.ObterPorId(id);
           if (entity == null)
             return null;
           Mapper.Map(livro, entity);
           await CommitAsync();
           return Mapper.Map<LivroViewModel>(entity);
       }

       public void Dispose()
       {
           _livroRepository.Dispose(); 
           GC.SuppressFinalize(this);
       }

  }
}
