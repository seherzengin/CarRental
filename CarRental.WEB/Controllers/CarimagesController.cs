using CarRental.Core.DTOs;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class CarimagesController : Controller
    {
        private readonly CarimageApiService _carimageApiService;
        private readonly CarApiService _carApiService;

        public CarimagesController(CarimageApiService carimageApiService, CarApiService carApiService)
        {
            _carimageApiService = carimageApiService;
            _carApiService = carApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _carimageApiService.GetSingleCarimageByIdWithCarAsync());
        }

        public async Task<IActionResult> Save()
        {
            var carsDto = await _carApiService.GetAllAsync();

            ViewBag.cars = new SelectList(carsDto, "Id", "Plaka");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarImageDto carImageDto)

        {


            if (ModelState.IsValid)
            {

                await _carimageApiService.SaveAsync(carImageDto);


                return RedirectToAction(nameof(Index));
            }

            var carsDto = await _carApiService.GetAllAsync();

            ViewBag.cars = new SelectList(carsDto, "Id", "Plaka");
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var carimage = await _carimageApiService.GetByIdAsync(id);


            var carsDto = await _carApiService.GetAllAsync();



            ViewBag.cars = new SelectList(carsDto, "Id", "Plaka", carimage.CarId);

            return View(carimage);

        }

        [HttpPost]
        public async Task<IActionResult> Update(CarImageDto carImageDto)
        {
            if (ModelState.IsValid)
            {

                await _carimageApiService.UpdateAsync(carImageDto);

                return RedirectToAction(nameof(Index));

            }

            var carsDto = await _carApiService.GetAllAsync();



            ViewBag.cars = new SelectList(carsDto, "Id", "Plaka", carImageDto.CarId);

            return View(carImageDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _carimageApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        


    }
}
