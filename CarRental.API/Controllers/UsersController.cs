using AutoMapper;
using CarRental.API.RabbitMQProducer;
using CarRental.Core.DTOs;
using CarRental.Core.Services;
using CarRental.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{

    public class UsersController : CustomBaseController
    {
        private readonly IService<User> _service;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRabbitMQProducer _rabitMQProducer;

        public UsersController(IService<User> service, IMapper mapper, IUserService userService, IRabbitMQProducer rabitMQProducer)
        {
            _service = service;
            _mapper = mapper;
            _userService = userService;
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var users = await _userService.GetAllAsync();

            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());

            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, usersDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
          
            var user = await _service.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(user);
            _rabitMQProducer.SendUserMessage(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, usersDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _service.UpdateAsync(_mapper.Map<User>(userDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(user);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetSingleUserByIdWithCustomer(int userId)
        {
            return CreateActionResult(await _userService.GetSingleUserByIdWithCustomerAsync(userId));
        }
    }
}
