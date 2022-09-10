using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class CreditcardsController : Controller
    {
        private readonly ICreditcardService _service;
        private readonly IMapper _mapper;

        public CreditcardsController(ICreditcardService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<CreditcardDto>>(response));
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreditcardDto creditCardDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Creditcard>(creditCardDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var creditCard = await _service.GetByIdAsync(id);


            var creditCards = await _service.GetAllAsync();

            var creditCardsDto = _mapper.Map<List<CreditcardDto>>(creditCards.ToList());

            ViewBag.cars = new SelectList(creditCardsDto, "Id", "CardName", creditCard);

            return View(_mapper.Map<CreditcardDto>(creditCard));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreditcardDto creditCardDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Creditcard>(creditCardDto));
                return RedirectToAction(nameof(Index));
            }

            var creditCards = await _service.GetAllAsync();

            var creditCardsDto = _mapper.Map<List<CreditcardDto>>(creditCards.ToList());

            ViewBag.creditCards = new SelectList(creditCardsDto, "Id", "CardName", creditCardDto);

            return View(creditCardDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var creditCard = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(creditCard);
            return RedirectToAction(nameof(Index));
        }
    }
}
