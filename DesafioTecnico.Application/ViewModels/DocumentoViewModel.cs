using DesafioTecnico.Infra.Data.Context;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioTecnico.Application.ViewModels
{
    public class DocumentoViewModel : DocumentoCreateViewModel
    {
        public int Id { get; set; }
        public string Departamento { get; set; }
        public string Categoria { get; set; }
        

    }

    public class DocumentoCreateViewModel
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public int DepartamentoId { get; set; }
        public int CategoriaId { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class DocumentoEditViewModel
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public int DepartamentoId { get; set; }
        public int CategoriaId { get; set; }
    }

    public class DocumentoCreateViewModelValidator : AbstractValidator<DocumentoCreateViewModel>
    {
        private readonly DesafioTecnicoDbContext _context;
        public DocumentoCreateViewModelValidator(DesafioTecnicoDbContext context)
        {
            _context = context;

            RuleFor(x => x.Codigo)
                .NotEmpty()
                .WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .WithMessage("{PropertyName} é obrigatório.")
                .Length(1, 20)
                .WithMessage("{PropertyName} deve conter somente 20 caracteres.")
                .MustAsync(CannotExistsAsync).WithMessage("Já existe este código cadastrado ({PropertyValue})."); ;

            RuleFor(x => x.Titulo)
              .NotEmpty()
              .WithMessage("{PropertyName} é obrigatório.")
              .NotNull()
              .WithMessage("{PropertyName} é obrigatório.")
              .Length(1, 200)
              .WithMessage("{PropertyName} deve conter somente 200 caracteres.");

            RuleFor(x => x.CategoriaId)
                .NotNull()
                .WithMessage("{PropertyName} é obrigatório.")
                .GreaterThan(0).WithMessage("Selecione {PropertyName}, campo obrigatório.");

            RuleFor(x => x.DepartamentoId)
               .NotNull()
               .WithMessage("{PropertyName} é obrigatório.")
               .GreaterThan(0).WithMessage("Selecione {PropertyName}, campo obrigatório.");
        }

        private async Task<bool> CannotExistsAsync(DocumentoCreateViewModel dto, string property, PropertyValidatorContext arg3, CancellationToken ct)
        {

            return !await _context.Documento
                .AsNoTracking()
                .AnyAsync(e => e.Codigo == property, ct);
        }
    }
}
