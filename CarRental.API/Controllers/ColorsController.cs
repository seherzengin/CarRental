using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{

    public class ColorsController : CustomBaseController
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ColorsController(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var colors = await _colorService.GetAllAsync();

            var colorsDto = _mapper.Map<List<ColorDto>>(colors.ToList());

            return CreateActionResult(CustomResponseDto<List<ColorDto>>.Success(200, colorsDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var color = await _colorService.GetByIdAsync(id);
            var colorsDto = _mapper.Map<ColorDto>(color);
            return CreateActionResult(CustomResponseDto<ColorDto>.Success(200, colorsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ColorDto colorDto)
        {
            var color = await _colorService.AddAsync(_mapper.Map<Color>(colorDto));
            var colorsDto = _mapper.Map<ColorDto>(color);
            return CreateActionResult(CustomResponseDto<ColorDto>.Success(201, colorsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ColorDto colorDto)
        {
            await _colorService.UpdateAsync(_mapper.Map<Color>(colorDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var car = await _colorService.GetByIdAsync(id);

            await _colorService.RemoveAsync(car);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]/{colorId}")]
        public async Task<IActionResult> GetSingleColorByIdWithCar(int colorId)
        {
            return CreateActionResult(await _colorService.GetSingleColorByIdWithCarAsync(colorId));
        }
    }
}
