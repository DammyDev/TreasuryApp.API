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
        Task<CompanyResponse> UpdateAsync(int id, Company company);
        Task<CompanyResponse> DeleteAsync(int id);
    }
}