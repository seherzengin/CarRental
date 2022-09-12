using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class FindeksController : Controller
    {
        private readonly FindekApiService _findekApiService;

        public FindeksController(FindekApiService findekApiService)
        {
            _findekApiService = findekApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _findekApiService.GetAllAsync());
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(FindekDto findekDto)
        {
            if (ModelState.IsValid)
            {
                await _findekApiService.SaveAsync(findekDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _findekApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FindekDto findekDto)
        {
            if (ModelState.IsValid)
            {
                await _findekApiService.UpdateAsync(findekDto);
                return RedirectToAction(nameof(Index));
            }
            return View(findekDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _findekApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
