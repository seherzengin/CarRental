using CarRental.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Validations
{
    public class BrandDtoValidator:AbstractValidator<BrandDto>
    {
        public BrandDtoValidator()
        {
            RuleFor(x => x.BrandsName).NotNull().WithMessage("{PropertyBrandsName} is required").NotEmpty().WithMessage("{PropertyBrandsName} is required");
        }
        
    }
}
