using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ApiService _apiService;

        public BrandsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            var brands = await _apiService.GetAllAsync<BrandDto>("brands");
            return View(brands); 
        }

        public async Task<IActionResult> Save()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BrandDto brandDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<BrandDto>("Brands", brandDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _apiService.GetByIdAsync<BrandDto>($"brands/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<BrandDto>("Brands", brandDto);
                return RedirectToAction(nameof(Index));
            }
            return View(brandDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Brands/{id}");
            return RedirectToAction(nameof(Index));
        }

        
    }
}
