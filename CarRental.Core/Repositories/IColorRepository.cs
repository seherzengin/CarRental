using CarRental.Repository.Models;

namespace CarRental.Core.Repositories
{
    public interface IColorRepository:IGenericRepository<Color>
    {
        Task<Color> GetSingleColorByIdWithCarAsync(int colorId);
    }
}
