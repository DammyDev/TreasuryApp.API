using System.Threading.Tasks;
using TreasuryApp.API.Domain.Repositories;
using TreasuryApp.API.Persistence.Contexts;

namespace TreasuryApp.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}