using CarRental.Core.DTOs;
using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRental.Repository.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(carrentaldbContext context) : base(context)
        {
            
        }

        public async Task<Car> GetByIdAsync()
        {
            return await _context.Cars
                                 .Include(c => c.Brand)
                                 .Include(c => c.Color)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCarWithCarImage()
        {
         return await _context.Cars.Include(x => x.Carimages).ToListAsync();
        }

        
    }
}
