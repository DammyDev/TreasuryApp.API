using System.Threading.Tasks;
using TreasuryApp.API.Domain.Models;
using TreasuryApp.API.Domain.Models.Queries;
using TreasuryApp.API.Domain.Services.Communication;

namespace TreasuryApp.API.Domain.Services
{
    public interface IProductService
    {
        Task<QueryResult<Product>> ListAsync(ProductsQuery query);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}