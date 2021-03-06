using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreasuryApp.API.Domain.Models;
using TreasuryApp.API.Domain.Repositories;
using TreasuryApp.API.Persistence.Contexts;

namespace TreasuryApp.API.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _context.Companies
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. 
            // Disabling entity tracking makes the code a little faster
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }

        public void Remove(Company company)
        {
            _context.Companies.Remove(company);
        }
    }
}