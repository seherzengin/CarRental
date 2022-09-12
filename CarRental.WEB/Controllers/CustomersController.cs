using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerApiService _customerApiService;
        private readonly UserApiService _userApiService;

        public CustomersController(CustomerApiService customerApiService, UserApiService userApiService)
        {
            _customerApiService = customerApiService;
            _userApiService = userApiService;
        }

        /*public async Task<IActionResult> Index()
        {

            return View(await _customerApiService.GetSingleCustomerByIdWithUserAsync());
        }
        */

        public async Task<IActionResult> Index()
        {

            return View(await _customerApiService.GetAllAsync());
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
                await _customerApiService.SaveAsync(customerDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _customerApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _customerApiService.UpdateAsync(customerDto);
                return RedirectToAction(nameof(Index));
            }
            return View(customerDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _customerApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
