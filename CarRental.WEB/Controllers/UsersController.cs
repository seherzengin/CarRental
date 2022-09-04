using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.WEB.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(_mapper.Map<List<UserDto>>(response));
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
                await _service.AddAsync(_mapper.Map<User>(userDto));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var user = await _service.GetByIdAsync(id);


            var users = await _service.GetAllAsync();

            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());

            ViewBag.users = new SelectList(usersDto, "Id", "FirstName", user);

            return View(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<User>(userDto));
                return RedirectToAction(nameof(Index));
            }

            var users = await _service.GetAllAsync();

            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());

            ViewBag.users = new SelectList(usersDto, "Id", "FirstName", userDto);

            return View(userDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
