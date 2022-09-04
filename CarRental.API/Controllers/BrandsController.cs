using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    
    public class BrandsController : CustomBaseController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var brands = await _brandService.GetAllAsync();

            var brandsDto = _mapper.Map<List<BrandDto>>(brands.ToList());

            return CreateActionResult(CustomResponseDto<List<BrandDto>>.Success(200, brandsDto));

        }

        [HttpGet("[action]/{brandId}")]
        public async Task<IActionResult> GetSingleBrandByIdWithCar(int brandId)
        {
            return CreateActionResult(await _brandService.GetSingleBrandByIdWithCarAsync(brandId));
        }
    }
}
