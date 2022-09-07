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

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments
                                 .Include(p => p.Customers)
                                 .Include(p => p.CreditCards)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Payment> GetPaymentByIdWithCustomerAsync(int paymentId)
        {
            return await _context.Payments.Include(x => x.Customers).Where(x => x.Id == paymentId).FirstOrDefaultAsync();
        }
    }
}
