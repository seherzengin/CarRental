using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{

    public class CarImagesController : CustomBaseController
    {
        private readonly ICarImageService _carImageService;
        private readonly IMapper _mapper;

        public CarImagesController(ICarImageService carImageService, IMapper mapper)
        {
            _carImageService = carImageService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var carImages = await _carImageService.GetAllAsync();

            var carImagesDto = _mapper.Map<List<CarImageDto>>(carImages.ToList());

            return CreateActionResult(CustomResponseDto<List<CarImageDto>>.Success(200, carImagesDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var carImage = await _carImageService.GetByIdAsync(id);
            var carImagesDto = _mapper.Map<CarImageDto>(carImage);
            return CreateActionResult(CustomResponseDto<CarImageDto>.Success(200, carImagesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarImageDto carImageDto)
        {
            var carImage = await _carImageService.AddAsync(_mapper.Map<Carimage>(carImageDto));
            var carImagesDto = _mapper.Map<CarImageDto>(carImage);
            return CreateActionResult(CustomResponseDto<CarImageDto>.Success(201, carImagesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarImageDto carImageDto)
        {
            await _carImageService.UpdateAsync(_mapper.Map<Carimage>(carImageDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var carImage = await _carImageService.GetByIdAsync(id);

            await _carImageService.RemoveAsync(carImage);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]/{carimageId}")]
        public async Task<IActionResult> GetSingleCarimageByIdWithCar(int carimageId)
        {
            return CreateActionResult(await _carImageService.GetSingleCarimageByIdWithCarAsync(carimageId));
        }
    }
}
