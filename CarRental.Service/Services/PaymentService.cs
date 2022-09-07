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
    public class PaymentService : Service<Payment>, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IGenericRepository<Payment> repository, IUnitOfWork unitOfWork, IPaymentRepository paymentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<PaymentDto>> GetByIdAsync(int Id)
        {
            var payment = await _paymentRepository.GetByIdAsync(Id);

            var paymentDto = _mapper.Map<PaymentDto>(payment);
            return CustomResponseDto<PaymentDto>.Success(200, paymentDto);
        }

        public async Task<CustomResponseDto<PaymentWithCustomerDto>> GetPaymentByIdWithCustomerAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetPaymentByIdWithCustomerAsync(paymentId);
            var paymentDto = _mapper.Map<PaymentWithCustomerDto>(payment);
            return CustomResponseDto<PaymentWithCustomerDto>.Success(200, paymentDto);
        }
    }
}
