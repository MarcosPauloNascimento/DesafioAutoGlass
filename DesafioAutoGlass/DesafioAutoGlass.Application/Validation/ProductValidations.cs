using DesafioAutoGlass.Domain.Entities;
using FluentValidation;
using System;

namespace DesafioAutoGlass.Application.Validations
{
    public class ProductValidations : AbstractValidator<Product>
    {
        public ProductValidations()
        {
            RuleFor(u => u.Description)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .Length(2, 200)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Status)
                    .NotNull().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(u => u.ManufacturingDate)
                    .LessThan(p => DateTime.Now)
                    .WithMessage("A data de fabricação não pode ser maior do que hoje");

            RuleFor(u => u.ExpirationDate)
                    .GreaterThan(p => p.ManufacturingDate)
                    .WithMessage("A data de validade deve ser maior do que a data de fabricação");

        }
    }
}
