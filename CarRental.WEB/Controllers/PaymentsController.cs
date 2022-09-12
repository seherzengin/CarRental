using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly PaymentApiService _paymentApiService;

        public PaymentsController(PaymentApiService paymentApiService)
        {
            _paymentApiService = paymentApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _paymentApiService.GetAllAsync());
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
                await _paymentApiService.SaveAsync(paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _paymentApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PaymentDto paymentDto)
        {
            if (ModelState.IsValid)
            {
                await _paymentApiService.UpdateAsync(paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _paymentApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
