using CarRental.Core.DTOs;
using CarRental.Repository.Models;

namespace CarRental.Core.Services
{
    public interface IUserService:IService<User>
    {
        Task<CustomResponseDto<UserWithCustomerDto>> GetSingleUserByIdWithCustomerAsync(int userId);
    }
}
