namespace BugStore.Application.Validators;
using FluentValidation;
using global::BugStore.Application.Services.Customers.Dto.Request;



public class CustomerRequestValidator : AbstractValidator<CustomerRequest>
{
    public CustomerRequestValidator()
    {        
             RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name é obrigatório")
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Nome é obrigatório")
            .MaximumLength(100)
            .WithMessage("O nome deve ter no máximo 100 caracteres");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email é obrigatório")
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Email é obrigatório")
            .EmailAddress()
            .WithMessage("Email inválido");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("O telefone é obrigatório")
            .Matches(@"^\d{10,11}$")
            .WithMessage("O telefone deve ter entre 10 e 11 dígitos");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage("A data de nascimento é obrigatória")
            .LessThan(DateTime.Now)
            .WithMessage("A data de nascimento não pode ser no futuro");
           
    }
    
}
