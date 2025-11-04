using BugStore.Application.Services.Products.Dto.Request;
using FluentValidation;

namespace BugStore.Application.Validators;
public class ProductRequestValidators : AbstractValidator<ProductDtoRequest>
{
    public ProductRequestValidators()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title é obrigatório")
            .Must(title => !string.IsNullOrWhiteSpace(title))
            .WithMessage("Title é obrigatório");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description é obrigatório")
            .Must(description => !string.IsNullOrWhiteSpace(description))
            .WithMessage("Description é obrigatório");

        RuleFor(x=> x.Price)            
            .NotEmpty()
            .WithMessage("Price é obrigatório")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price não pode ser menor que zero");



    }
}
