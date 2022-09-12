using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class CarsController : Controller
    {

        private readonly CarApiService _carApiService;

        public CarsController(CarApiService carApiService)
        {
            _carApiService = carApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _carApiService.GetAllAsync());
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
                await _carApiService.SaveAsync(carDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            
            var address = await _carApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                await _carApiService.UpdateAsync(carDto);
                return RedirectToAction(nameof(Index));
            }
            return View(carDto);
            
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _carApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
