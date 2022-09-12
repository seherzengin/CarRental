using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class PaymentsController : CustomBaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var payments = await _paymentService.GetAllAsync();

            var paymentsDto = _mapper.Map<List<PaymentDto>>(payments.ToList());

            return CreateActionResult(CustomResponseDto<List<PaymentDto>>.Success(200, paymentsDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            var paymentDto = _mapper.Map<PaymentDto>(payment);
            return CreateActionResult(CustomResponseDto<PaymentDto>.Success(200, paymentDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PaymentDto paymentDto)
        {
            var payment = await _paymentService.AddAsync(_mapper.Map<Payment>(paymentDto));
            var paymentsDto = _mapper.Map<PaymentDto>(payment);
            return CreateActionResult(CustomResponseDto<PaymentDto>.Success(201, paymentsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PaymentDto paymentDto)
        {
            await _paymentService.UpdateAsync(_mapper.Map<Payment>(paymentDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);

            await _paymentService.RemoveAsync(payment);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPaymentByIdWithCustomer(int paymentId)
        {
            return CreateActionResult(await _paymentService.GetPaymentByIdWithCustomerAsync(paymentId));
        }
    }
}
