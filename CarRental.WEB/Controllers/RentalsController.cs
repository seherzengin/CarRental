using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _service;
        private readonly IMapper _mapper;

        public RentalsController(IRentalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<RentalDto>>(response));
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(RentalDto rentalDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Rental>(rentalDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var rental = await _service.GetByIdAsync(id);


            var rentals = await _service.GetAllAsync();

            var rentalsDto = _mapper.Map<List<RentalDto>>(rentals.ToList());

            ViewBag.rentals = new SelectList(rentalsDto, "Id", "RentDate", rental);

            return View(_mapper.Map<RentalDto>(rental));
        }

        [HttpPost]
        public async Task<IActionResult> Update(RentalDto rentalDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Rental>(rentalDto));
                return RedirectToAction(nameof(Index));
            }

            var rentals = await _service.GetAllAsync();

            var rentalsDto = _mapper.Map<List<RentalDto>>(rentals.ToList());

            ViewBag.rentals = new SelectList(rentalsDto, "Id", "RentDate", rentalDto);

            return View(rentalDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var rental = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(rental);
            return RedirectToAction(nameof(Index));
        }
    }
}
