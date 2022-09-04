using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;

namespace CarRental.Service.Services
{
    public class CarServiceNoCaching : Service<Car>, ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarServiceNoCaching(IGenericRepository<Car> repository, IUnitOfWork unitOfWork, ICarRepository carRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CarDto>> GetCarByIdAsync(int Id)
        {
            var car = await _carRepository.GetCarByIdAsync(Id);

            var carDto = _mapper.Map<CarDto>(car);
            return CustomResponseDto<CarDto>.Success(200, carDto);
        }

        public async Task<CustomResponseDto<List<CarWithCarImageDto>>> GetCarWithCarImage()
        {
            var cars = await _carRepository.GetCarWithCarImage();

            var carsDto = _mapper.Map<List<CarWithCarImageDto>>(cars);
            return CustomResponseDto<List<CarWithCarImageDto>>.Success(200, carsDto);
        }

       
    }
}
