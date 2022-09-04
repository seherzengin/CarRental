using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
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

        [HttpGet("[action]/{paymentId}")]
        public async Task<IActionResult> GetPaymentByIdWithCustomer(int paymentId)
        {
            return CreateActionResult(await _paymentService.GetPaymentByIdWithCustomerAsync(paymentId));
        }
    }
}
