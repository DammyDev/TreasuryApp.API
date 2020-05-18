using System.Threading.Tasks;

namespace TreasuryApp.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}