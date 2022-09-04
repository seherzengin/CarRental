using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Customer> GetSingleCustomerByIdWithUserAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.User).Where(x => x.Id == customerId).FirstOrDefaultAsync();
        }
    }
}
