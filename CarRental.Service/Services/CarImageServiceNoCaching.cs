using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Services
{
    public class CarImageServiceNoCaching : Service<Carimage>, ICarImageService
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;
        public CarImageServiceNoCaching(IGenericRepository<Carimage> repository, IUnitOfWork unitOfWork, ICarImageRepository carImageRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CarImageWithCarsDto>> GetSingleCarimageByIdWithCarAsync(int carimageId)
        {
            var carImage = await _carImageRepository.GetSingleCarimageByIdWithCarAsync(carimageId);
            var carImageDto = _mapper.Map<CarImageWithCarsDto>(carImage);
            return CustomResponseDto<CarImageWithCarsDto>.Success(200, carImageDto);
        }
    }
}
