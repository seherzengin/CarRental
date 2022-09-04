using CarRental.Core.DTOs;
using CarRental.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Services
{
    public interface ICarImageService:IService<Carimage>
    {
        public Task<CustomResponseDto<CarImageWithCarsDto>> GetSingleCarimageByIdWithCarAsync(int carimageId);

    }
}
