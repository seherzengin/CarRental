using CarRental.Core.DTOs;
using CarRental.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Services
{
    public interface IPaymentService:IService<Payment>
    {
        public Task<CustomResponseDto<PaymentWithCustomerDto>> GetPaymentByIdWithCustomerAsync(int paymentId);
    }
}
