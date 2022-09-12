using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            var brandsDto = _mapper.Map<BrandDto>(brand);
            return CreateActionResult(CustomResponseDto<BrandDto>.Success(200, brandsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BrandDto brandDto)
        {
            var brand = await _brandService.AddAsync(_mapper.Map<Brand>(brandDto));
            var brandsDto = _mapper.Map<BrandDto>(brand);
            return CreateActionResult(CustomResponseDto<BrandDto>.Success(201, brandsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            await _brandService.UpdateAsync(_mapper.Map<Brand>(brandDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);

            await _brandService.RemoveAsync(brand);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]/{brandId}")]
        public async Task<IActionResult> GetSingleBrandByIdWithCar(int brandId)
        {
            return CreateActionResult(await _brandService.GetSingleBrandByIdWithCarAsync(brandId));
        }
    }
}
