using StockViewer.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockViewer.Domain.Services.Data
{
    public interface IUserStockMappingDataService : IDataService<UserStockMapping>
    {

        Task<IEnumerable<UserStockMapping>> GetStocksForUserAsync(int userId);

        Task DeleteStockForUserAsync(int userId, int stockId);

        Task<UserStockMapping> AddStockForUserAsync(UserStockMapping userStockMapping);
    }
}
