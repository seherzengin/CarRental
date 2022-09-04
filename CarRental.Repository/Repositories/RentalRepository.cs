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
    public class RentalRepository : GenericRepository<Rental>, IRentalRepository
    {
        public RentalRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Rental> GetRentalByIdWithCustomerAsync(int rentalId)
        {
            return await _context.Rentals.Include(x => x.Customer).Where(x => x.Id == rentalId).FirstOrDefaultAsync();
        }
    }
}
