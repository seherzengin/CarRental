using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Payment> GetPaymentByIdWithCustomerAsync(int paymentId)
        {
            return await _context.Payments.Include(x => x.Customers).Where(x => x.Id == paymentId).FirstOrDefaultAsync();
        }
    }
}
