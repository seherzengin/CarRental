using CarRental.Repository.Models;

namespace CarRental.Core.Repositories
{
    public interface IFindekRepository:IGenericRepository<Findek>
    {
        Task<Findek> GetSingleFindekByIdWithCustomerAsync(int findekId);
    }
}
