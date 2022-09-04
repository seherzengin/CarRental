using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
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

        [HttpGet("[action]/{colorId}")]
        public async Task<IActionResult> GetSingleBrandByIdWithCar(int colorId)
        {
            return CreateActionResult(await _colorService.GetSingleColorByIdWithCarAsync(colorId));
        }
    }
}
