using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class CarimagesController : Controller
    {
        private readonly ApiService _apiService;

        public CarimagesController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            var carImages = await _apiService.GetAllAsync<CarImageDto>("carimages");
            return View(carImages);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarImageDto carImageDto)

        {
            if (ModelState.IsValid)
            {

                await _apiService.SaveAsync<CarImageDto>("Carimages", carImageDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var address = await _apiService.GetByIdAsync<CarImageDto>($"Carimages/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarImageDto carImageDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<CarImageDto>("Carimages", carImageDto);
                return RedirectToAction(nameof(Index));
            }
            return View(carImageDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Carimages/{id}");
            return RedirectToAction(nameof(Index));
        }

        


    }
}
