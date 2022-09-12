using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;

namespace CarRental.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<UserWithCustomerDto>> GetSingleUserByIdWithCustomerAsync(int userId)
        {
            var user = await _userRepository.GetSingleUserByIdWithCustomerAsync(userId);
            var userDto = _mapper.Map<UserWithCustomerDto>(user);
            return CustomResponseDto<UserWithCustomerDto>.Success(200, userDto);
        }
    }

}
