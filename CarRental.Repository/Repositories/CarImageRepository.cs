using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository.Repositories
{
    public class CarImageRepository : GenericRepository<Carimage>, ICarImageRepository
    {
        public CarImageRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Carimage> GetSingleCarimageByIdWithCarAsync(int carimageId)
        {
            return await _context.Carimages.Include(x => x.Car).FirstOrDefaultAsync();
        }
    }
}
