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
                    .NotNull().WithMessage("O campo descrição do produto deve ser preenchido")
                    .Length(2, 200)
                    .WithMessage("O campo descrição do produto precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(u => u.Status)
                    .NotNull().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(u => u.ManufacturingDate)
                    .LessThan(p => DateTime.UtcNow)
                    .WithMessage("A data de fabricação não pode ser maior do que hoje");

            RuleFor(u => u.ExpirationDate)
                    .GreaterThan(p => p.ManufacturingDate)
                    .WithMessage("A data de validade deve ser maior do que a data de fabricação");

        }
    }
}
