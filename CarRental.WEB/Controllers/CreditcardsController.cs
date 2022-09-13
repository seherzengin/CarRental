using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class CreditcardsController : Controller
    {
        private readonly ApiService _apiService;

        public CreditcardsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var creditcards = await _apiService.GetAllAsync<CreditcardDto>("creditcards");
            return View(creditcards);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreditcardDto creditcardDto)
        {

            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<CreditcardDto>("Creditcards", creditcardDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var address = await _apiService.GetByIdAsync<CreditcardDto>($"Creditcards/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreditcardDto creditcardDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<CreditcardDto>("Creditcards", creditcardDto);
                return RedirectToAction(nameof(Index));
            }

            return View(creditcardDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Creditcards/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
