using DesafioAutoGlass.Domain.Entities;
using FluentValidation;

namespace DesafioAutoGlass.Application.Validations
{
    public class SupplierValidations : AbstractValidator<Supplier>
    {
        public SupplierValidations()
        {
            RuleFor(u => u.Description)
                    .NotEmpty().WithMessage("O campo descricao do fornecedor é obrigatório")
                    .Length(2, 200)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.CNPJ)
                    .NotNull().WithMessage("O campo {PropertyName} é obrigatório")
                    .Length(14);

        }
    }
}
