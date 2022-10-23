using CarRental.Core.DTOs;
using FluentValidation;

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
