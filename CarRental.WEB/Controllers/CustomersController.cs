using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApiService _apiService;

        public CustomersController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _apiService.GetAllAsync<CustomerDto>("customers");
            return View(customers);
        }



        public async Task<IActionResult> Save()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<CustomerDto>("Customers", customerDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _apiService.GetByIdAsync<CustomerDto>($"Customers/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<CustomerDto>("Customers", customerDto);
                return RedirectToAction(nameof(Index));
            }
            return View(customerDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Cars/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
