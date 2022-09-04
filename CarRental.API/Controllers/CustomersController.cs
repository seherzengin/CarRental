using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var customers = await _customerService.GetAllAsync();

            var customersDto = _mapper.Map<List<CustomerDto>>(customers.ToList());

            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customersDto));

        }

        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetSingleCustomerByIdWithUser(int customerId)
        {
            return CreateActionResult(await _customerService.GetSingleCustomerByIdWithUserAsync(customerId));
        }
    }
}
