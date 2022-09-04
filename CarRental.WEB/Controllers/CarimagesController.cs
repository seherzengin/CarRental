using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class CarimagesController : Controller
    {
        private readonly ICarImageService _service;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarimagesController(ICarImageService service, IMapper mapper, ICarService carService)
        {
            _service = service;
            _mapper = mapper;
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<CarImageDto>>(response));
        }


        public async Task<IActionResult> Save()
        {
            var cars = await _carService.GetAllAsync();
            var carDto = _mapper.Map<List<CarDto>>(cars.ToList());
            ViewBag.cars = new SelectList(carDto, "Id","Plaka");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarImageDto carImageDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Carimage>(carImageDto));
                return RedirectToAction(nameof(Index));
            }
            var cars = await _carService.GetAllAsync();
            var carDto = _mapper.Map<List<CarDto>>(cars.ToList());
            ViewBag.cars = new SelectList(carDto, "Id","Plaka");
            return View();
        }


        public async Task<IActionResult> Update(int id)
        {
            var carImage = await _service.GetByIdAsync(id);


            var carImages = await _service.GetAllAsync();

            var carImagesDto = _mapper.Map<List<CarImageDto>>(carImages.ToList());

            ViewBag.carImages = new SelectList(carImagesDto, "Id", "Plaka", carImage);

            return View(_mapper.Map<CarImageDto>(carImage));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarImageDto carImageDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Carimage>(carImageDto));
                return RedirectToAction(nameof(Index));
            }

            var carimages = await _service.GetAllAsync();

            var carimagesDto = _mapper.Map<List<CarImageDto>>(carimages.ToList());

            ViewBag.carimages = new SelectList(carimagesDto, "Id", "Plaka", carImageDto);

            return View(carImageDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var carImage = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(carImage);
            return RedirectToAction(nameof(Index));
        }


    }
}
