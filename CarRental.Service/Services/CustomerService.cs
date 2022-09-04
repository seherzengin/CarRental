using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Core.Services;
using CarRental.Core.UnitOfWorks;
using CarRental.Repository.Models;

namespace CarRental.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CustomerWithUserDto>> GetSingleCustomerByIdWithUserAsync(int customerId)
        {
            var customer = await _customerRepository.GetSingleCustomerByIdWithUserAsync(customerId);
            var customerDto = _mapper.Map<CustomerWithUserDto>(customer);
            return CustomResponseDto<CustomerWithUserDto>.Success(200, customerDto);
        }
    }
}
