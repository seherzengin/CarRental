using CarRental.Core.DTOs;
using CarRental.Repository.Models;

namespace CarRental.Core.Services
{
    public interface IColorService:IService<Color>
    {
        public Task<CustomResponseDto<ColorWithCarsDto>> GetSingleColorByIdWithCarAsync(int colorId);
    }
}
