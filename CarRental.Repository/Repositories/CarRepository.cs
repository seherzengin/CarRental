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

        public async Task<Car> GetCarByIdAsync(int Id)
        {
            return await _context.Cars
                                 .Include(x => x.BrandId)
                                 .Include(x => x.ColorId)
                                 .Where(x => x.Id == Id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCarWithCarImage()
        {
         return await _context.Cars.Include(x => x.Carimages).ToListAsync();
        }

        
    }
}
