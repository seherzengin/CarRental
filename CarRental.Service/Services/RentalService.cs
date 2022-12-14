using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;

namespace CarRental.Service.Services
{
    public class RentalService : Service<Rental>, IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;
        public RentalService(IGenericRepository<Rental> repository, IUnitOfWork unitOfWork, IRentalRepository rentalRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<RentalDto>> GetByIdAsync(int Id)
        {
            var rental = await _rentalRepository.GetByIdAsync(Id);

            var rentalDto = _mapper.Map<RentalDto>(rental);
            return CustomResponseDto<RentalDto>.Success(200, rentalDto);
        }

        public async Task<CustomResponseDto<RentalWithCustomerDto>> GetRentalByIdWithCustomerAsync(int rentalId)
        {
            var rental = await _rentalRepository.GetRentalByIdWithCustomerAsync(rentalId);
            var rentalDto = _mapper.Map<RentalWithCustomerDto>(rental);
            return CustomResponseDto<RentalWithCustomerDto>.Success(200, rentalDto);
        }
    }
}
