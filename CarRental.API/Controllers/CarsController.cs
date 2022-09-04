using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{

    public class CarsController : CustomBaseController
    {
        
        private readonly IMapper _mapper;
        private readonly ICarService _service;

        public CarsController(IMapper mapper,ICarService service)
        {

            _mapper = mapper;
            _service = service;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarWithCarImage()
        {

            return CreateActionResult(await _service.GetCarWithCarImage());
        }

        

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cars = await _service.GetAllAsync();
            var carsDtos = _mapper.Map<List<CarDto>>(cars.ToList());
            return CreateActionResult(CustomResponseDto<List<CarDto>>.Success(200, carsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _service.GetByIdAsync(id);
            var carsDto = _mapper.Map<CarDto>(car);
            return CreateActionResult(CustomResponseDto<CarDto>.Success(200, carsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarDto carDto)
        {
            var car = await _service.AddAsync(_mapper.Map<Car>(carDto));
            var carsDto = _mapper.Map<CarDto>(car);
            return CreateActionResult(CustomResponseDto<CarDto>.Success(201, carsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarDto carDto)
        {
            await _service.UpdateAsync(_mapper.Map<Car>(carDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var car = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(car);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCarByIdAsync(int id)
        {
            var car = await _service.GetCarByIdAsync(id);
            var carDto = _mapper.Map<CarDto>(car);
            return CreateActionResult(CustomResponseDto<CarDto>.Success(200, carDto));
        }

    }
}
