using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class FindeksController : Controller
    {
        private readonly ApiService _apiService;

        public FindeksController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            var findeks = await _apiService.GetAllAsync<FindekDto>("findeks");
            return View(findeks);
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
                await _apiService.SaveAsync<FindekDto>("Findeks", findekDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _apiService.GetByIdAsync<FindekDto>($"Findeks/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FindekDto findekDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<FindekDto>("Findeks", findekDto);
                return RedirectToAction(nameof(Index));
            }
            return View(findekDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Findeks/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
