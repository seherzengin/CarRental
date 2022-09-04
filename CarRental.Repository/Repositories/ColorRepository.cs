using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Color> GetSingleColorByIdWithCarAsync(int colorId)
        {
            return await _context.Colors.Include(x => x.Cars).Where(x => x.Id == colorId).FirstOrDefaultAsync();
        }
    }
}
