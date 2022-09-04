using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository.Repositories
{
    public class FindekRepository : GenericRepository<Findek>, IFindekRepository
    {
        public FindekRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Findek> GetSingleFindekByIdWithCustomerAsync(int findekId)
        {
            return await _context.Findeks.Include(x => x.Customer).Where(x => x.Id == findekId).FirstOrDefaultAsync();
        }
    }
}
