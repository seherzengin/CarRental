using CarRental.Repository.Models;

namespace CarRental.Core.Repositories
{
    public interface IRentalRepository:IGenericRepository<Rental>
    {
        Task<Rental> GetRentalByIdWithCustomerAsync(int rentalId);
    }
}
