using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ApiService _apiService;

        public ColorsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            var colors = await _apiService.GetAllAsync<ColorDto>("colors");
            return View(colors);
        }

        public async Task<IActionResult> Save()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ColorDto colorDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<ColorDto>("Colors", colorDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _apiService.GetByIdAsync<ColorDto>($"Colors/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ColorDto colorDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<ColorDto>("Colors", colorDto);
                return RedirectToAction(nameof(Index));
            }
            return View(colorDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Colors/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
