using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class CarsController : Controller
    {

        private readonly ApiService _apiService;

        public CarsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            var cars = await _apiService.GetAllAsync<CarDto>("cars");
            return View(cars);
        }

        public async Task<IActionResult> Save()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<CarDto>("Cars", carDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            
            var address = await _apiService.GetByIdAsync<CarDto>($"Cars/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<CarDto>("Cars", carDto);
                return RedirectToAction(nameof(Index));
            }
            return View(carDto);
            
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Cars/{id}");
            return RedirectToAction(nameof(Index));
        }

        
    }
}
