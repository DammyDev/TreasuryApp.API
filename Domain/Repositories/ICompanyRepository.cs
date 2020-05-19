using System.Collections.Generic;
using System.Threading.Tasks;
using TreasuryApp.API.Domain.Models;

namespace TreasuryApp.API.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ListAsync();
        Task AddAsync(Company company);
        //Task<Category> FindByIdAsync(int id);
        //void Update(Category category);
        //void Remove(Category category);
    }
}