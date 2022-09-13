using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApiService _apiService;

        public UsersController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _apiService.GetAllAsync<UserDto>("users");
            return View(users);
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SaveAsync<UserDto>("Users", userDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var address = await _apiService.GetByIdAsync<UserDto>($"Users/{id}");
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _apiService.UpdateAsync<UserDto>("Users", userDto);
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
            
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _apiService.RemoveAsync($"Users/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
