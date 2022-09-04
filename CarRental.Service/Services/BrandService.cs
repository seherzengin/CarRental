using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;

namespace CarRental.Service.Services
{
    public class BrandService : Service<Brand>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandService(IGenericRepository<Brand> repository, IUnitOfWork unitOfWork, IBrandRepository brandRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<BrandWithCarsDto>> GetSingleBrandByIdWithCarAsync(int brandId)
        {
            var brand = await _brandRepository.GetSingleBrandByIdWithCarAsync(brandId);
            var brandDto = _mapper.Map<BrandWithCarsDto>(brand);
            return CustomResponseDto<BrandWithCarsDto>.Success(200, brandDto);
        }
    }
}
