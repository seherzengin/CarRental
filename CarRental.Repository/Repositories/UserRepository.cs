using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<User> GetSingleUserByIdWithCustomerAsync(int userId)
        {
            return await _context.Users.Include(x => x.Customers).Where(x => x.Id == userId).FirstOrDefaultAsync();
        }
    }
}
