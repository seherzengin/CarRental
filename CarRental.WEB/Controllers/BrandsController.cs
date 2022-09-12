using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class BrandsController : Controller
    {
        private readonly BrandApiService _brandApiService;

        public BrandsController(BrandApiService brandApiService)
        {
            _brandApiService = brandApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _brandApiService.GetAllAsync());
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
                await _brandApiService.SaveAsync(brandDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            
            var address = await _brandApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            if (ModelState.IsValid)
            {
                await _brandApiService.UpdateAsync(brandDto);
                return RedirectToAction(nameof(Index));
            }
            return View(brandDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _brandApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
