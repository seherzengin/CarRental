using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _service;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<PaymentDto>>(response));
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
                await _service.AddAsync(_mapper.Map<Payment>(paymentDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var payment = await _service.GetByIdAsync(id);


            var payments = await _service.GetAllAsync();

            var paymentsDto = _mapper.Map<List<PaymentDto>>(payments.ToList());

            ViewBag.payments = new SelectList(paymentsDto, "Id", "PaymentDate", payment);

            return View(_mapper.Map<PaymentDto>(payment));
        }

        [HttpPost]
        public async Task<IActionResult> Update(PaymentDto paymentDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Payment>(paymentDto));
                return RedirectToAction(nameof(Index));
            }

            var payments = await _service.GetAllAsync();

            var paymentsDto = _mapper.Map<List<PaymentDto>>(payments.ToList());

            ViewBag.payments = new SelectList(paymentsDto, "Id", "PaymentDate", paymentDto);

            return View(paymentDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var payment = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(payment);
            return RedirectToAction(nameof(Index));
        }
    }
}
