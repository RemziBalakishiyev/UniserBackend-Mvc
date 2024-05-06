using BusinessLogic.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidations
{
    internal class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(10).LessThan(100);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).LessThan(1000);
        }
    }
}
