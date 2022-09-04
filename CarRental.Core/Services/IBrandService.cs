using CarRental.Core.DTOs;
using CarRental.Repository.Models;

namespace CarRental.Core.Services
{
    public interface IBrandService:IService<Brand>
    {
        public Task<CustomResponseDto<BrandWithCarsDto>> GetSingleBrandByIdWithCarAsync(int brandId);
    }
}
