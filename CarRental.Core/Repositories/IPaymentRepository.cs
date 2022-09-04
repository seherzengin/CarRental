using CarRental.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Repositories
{
    public interface IPaymentRepository:IGenericRepository<Payment>
    {
        Task<Payment> GetPaymentByIdWithCustomerAsync(int paymentId);
    }
}
