using CarRental.Core.DTOs;
using CarRental.Repository.Models;

namespace CarRental.Core.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<List<Car>> GetCarWithCarImage();

    }
}
