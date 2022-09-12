using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class CreditcardsController : Controller
    {
        private readonly CreditcardApiService _creditcardApiService;
        private readonly UserApiService _userApiService;

        public CreditcardsController(CreditcardApiService creditcardApiService, UserApiService userApiService)
        {
            _creditcardApiService = creditcardApiService;
            _userApiService = userApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _creditcardApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {
            var usersDto = await _userApiService.GetAllAsync();

            ViewBag.users = new SelectList(usersDto, "Id", "FirstName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreditcardDto creditcardDto)

        {


            if (ModelState.IsValid)
            {

                await _creditcardApiService.SaveAsync(creditcardDto);


                return RedirectToAction(nameof(Index));
            }

            var usersDto = await _userApiService.GetAllAsync();

            ViewBag.users = new SelectList(usersDto, "Id", "FirstName");
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var address = await _creditcardApiService.GetByIdAsync(id);
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreditcardDto creditcardDto)
        {
            if (ModelState.IsValid)
            {
                await _creditcardApiService.UpdateAsync(creditcardDto);
                return RedirectToAction(nameof(Index));
            }
            return View(creditcardDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _creditcardApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
