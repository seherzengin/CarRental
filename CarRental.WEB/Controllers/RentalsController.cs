using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApiService _apiService;

        public RentalsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            var rentals = await _apiService.GetAllAsync<RentalDto>("rentals");
            return View(rentals);
        }

        public async Task<IActionResult> Save()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(RentalDto rentalDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<RentalDto>("Rentals", rentalDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _apiService.GetByIdAsync<RentalDto>($"Rentals/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RentalDto rentalDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<RentalDto>("Rentals", rentalDto);
                return RedirectToAction(nameof(Index));
            }
            return View(rentalDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Rentals/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
