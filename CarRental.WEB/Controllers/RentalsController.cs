using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class RentalsController : Controller
    {
        private readonly RentalApiService _rentalApiService;

        public RentalsController(RentalApiService rentalApiService)
        {
            _rentalApiService = rentalApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _rentalApiService.GetAllAsync());
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
                await _rentalApiService.SaveAsync(rentalDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _rentalApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RentalDto rentalDto)
        {
            if (ModelState.IsValid)
            {
                await _rentalApiService.UpdateAsync(rentalDto);
                return RedirectToAction(nameof(Index));
            }
            return View(rentalDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _rentalApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
