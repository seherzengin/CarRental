using CarRental.Core.UnitOfWorks;

namespace CarRental.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly carrentaldbContext _context;

        public UnitOfWork(carrentaldbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
