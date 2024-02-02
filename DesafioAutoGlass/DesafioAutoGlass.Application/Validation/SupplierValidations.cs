using DesafioAutoGlass.Domain.Entities;
using FluentValidation;

namespace DesafioAutoGlass.Application.Validations
{
    public class SupplierValidations : AbstractValidator<Supplier>
    {
        public SupplierValidations()
        {
            RuleFor(u => u.Description)
                    .NotNull().WithMessage("O campo descrição do fornecedor deve ser preenchido")
                    .Length(2, 200)
                    .WithMessage("O campo descrição do fornecedor precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.CNPJ)
                    .NotNull().WithMessage("O campo {PropertyName} deve ser preenchido")
                    .Length(14)
                    .WithMessage("O campo {PropertyName} deve conter 14 números");

        }
    }
}
