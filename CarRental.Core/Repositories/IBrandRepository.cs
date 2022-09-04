using CarRental.Repository.Models;

namespace CarRental.Core.Repositories
{
    public interface IBrandRepository:IGenericRepository<Brand>
    {
        Task<Brand> GetSingleBrandByIdWithCarAsync(int brandId);
    }
}
