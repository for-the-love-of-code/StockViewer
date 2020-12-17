using StockViewer.Domain.Models;
using System.Threading.Tasks;

namespace StockViewer.Domain.Services.Data
{
    public interface IUserDataService : IDataService<User>
    {
        Task<bool> UserNameExistsAsync(string userName);

        Task<User> GetByUserNameAsync(string userName);
    }
}
