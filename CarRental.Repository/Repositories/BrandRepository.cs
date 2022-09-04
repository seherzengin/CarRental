using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Brand> GetSingleBrandByIdWithCarAsync(int brandId)
        {
            return await _context.Brands.Include(x => x.Cars).Where(x => x.Id == brandId).FirstOrDefaultAsync();
        }
    }
}
