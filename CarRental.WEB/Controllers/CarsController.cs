using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _services;
        private readonly IMapper _mapper;

        public CarsController(ICarService services,IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        
        public async Task<IActionResult> Index()
        {
            var response = await _services.GetAllAsync();
            return View(_mapper.Map<List<CarDto>>(response));
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(_mapper.Map<Car>(carDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var car = await _services.GetByIdAsync(id);


            var cars = await _services.GetAllAsync();

            var carsDto = _mapper.Map<List<CarDto>>(cars.ToList());

            ViewBag.cars = new SelectList(carsDto, "Id", "Plaka", car);

            return View(_mapper.Map<CarDto>(car));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(_mapper.Map<Car>(carDto));
                return RedirectToAction(nameof(Index));
            }

            var cars = await _services.GetAllAsync();

            var carsDto = _mapper.Map<List<CarDto>>(cars.ToList());

            ViewBag.cars = new SelectList(carsDto, "Id", "Plaka", carDto);

            return View(carDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var car = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(car);
            return RedirectToAction(nameof(Index));
        }
    }
}
