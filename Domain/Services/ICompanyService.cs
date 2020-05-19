using System.Collections.Generic;
using System.Threading.Tasks;
using TreasuryApp.API.Domain.Models;
using TreasuryApp.API.Domain.Services.Communication;

namespace TreasuryApp.API.Domain.Services
{
    public interface ICompanyService
    {
         Task<IEnumerable<Company>> ListAsync();
         Task<CompanyResponse> SaveAsync(Company company);
         //Task<CategoryResponse> UpdateAsync(int id, Category category);
         //Task<CategoryResponse> DeleteAsync(int id);
    }
}