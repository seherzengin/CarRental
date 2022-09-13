using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ApiService _apiService;

        public PaymentsController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            var payments = await _apiService.GetAllAsync<PaymentDto>("payments");
            return View(payments);
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(PaymentDto paymentDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<PaymentDto>("Payments", paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _apiService.GetByIdAsync<PaymentDto>($"Payments/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PaymentDto paymentDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<PaymentDto>("Payments", paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Payments/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
