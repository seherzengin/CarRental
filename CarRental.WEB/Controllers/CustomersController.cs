using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, IMapper mapper, IUserService userService)
        {
            _service = service;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<CustomerDto>>(response));
        }

        public async Task<IActionResult> Save()
        {
            var users = await _userService.GetAllAsync();
            var userDto = _mapper.Map<List<UserDto>>(users.ToList());
            ViewBag.users = new SelectList(userDto, "Id");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Customer>(customerDto));
                return RedirectToAction(nameof(Index));
            }
            var users = await _userService.GetAllAsync();
            var userDto = _mapper.Map<List<UserDto>>(users.ToList());
            ViewBag.users = new SelectList(userDto, "Id");
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var customer = await _service.GetByIdAsync(id);


            var customers = await _service.GetAllAsync();

            var customersDto = _mapper.Map<List<CustomerDto>>(customers.ToList());

            ViewBag.customers = new SelectList(customersDto, "Id", "FirstName", customer);

            return View(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));
                return RedirectToAction(nameof(Index));
            }

            var customers = await _service.GetAllAsync();

            var customersDto = _mapper.Map<List<CustomerDto>>(customers.ToList());

            ViewBag.customers = new SelectList(customersDto, "Id", "FirstName", customerDto);

            return View(customerDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
