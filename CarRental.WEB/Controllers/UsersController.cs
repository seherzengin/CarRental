using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WEB.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserApiService _userApiService;

        public UsersController(UserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _userApiService.GetAllAsync());
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
                await _userApiService.SaveAsync(userDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var address = await _userApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userApiService.UpdateAsync(userDto);
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
            
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _userApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
