using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Http;
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


        [HttpGet("[action]/{carimageId}")]
        public async Task<IActionResult> GetSingleCarimageByIdWithCar(int carimageId)
        {
            return CreateActionResult(await _carImageService.GetSingleCarimageByIdWithCarAsync(carimageId));
        }
    }
}
