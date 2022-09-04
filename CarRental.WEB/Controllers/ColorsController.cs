using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class ColorsController : Controller
    {
        private readonly IColorService _service;
        private readonly IMapper _mapper;

        public ColorsController(IColorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<ColorDto>>(response));
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ColorDto colorDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Color>(colorDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var color = await _service.GetByIdAsync(id);


            var colors = await _service.GetAllAsync();

            var colorsDto = _mapper.Map<List<ColorDto>>(colors.ToList());

            ViewBag.colors = new SelectList(colorsDto, "Id", "ColorName", color);

            return View(_mapper.Map<ColorDto>(color));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ColorDto colorDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Color>(colorDto));
                return RedirectToAction(nameof(Index));
            }

            var colors = await _service.GetAllAsync();

            var colorsDto = _mapper.Map<List<ColorDto>>(colors.ToList());

            ViewBag.colors = new SelectList(colorsDto, "Id", "ColorName", colorDto);

            return View(colorDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var color = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(color);
            return RedirectToAction(nameof(Index));
        }
    }
}
