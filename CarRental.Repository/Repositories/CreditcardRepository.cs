using CarRental.Core.Repositories;
using CarRental.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repository.Repositories
{
    public class CreditcardRepository : GenericRepository<Creditcard>, ICreditcardRepository
    {
        public CreditcardRepository(carrentaldbContext context) : base(context)
        {
        }

        public async Task<Creditcard> GetSingleCreditcardByIdWithUserAsync(int creditCardId)
        {
            return await _context.Creditcards.Include(x => x.Users).Where(x => x.Id == creditCardId).FirstOrDefaultAsync();
        }
    }
}
