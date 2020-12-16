using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.Domain.Services.Data
{
    /// <summary>
    /// Single data service for all data models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> DeleteAsync(int id);

        Task<T> GetAsync(int id);

        Task<T> CreateAsync(T model);

        Task<T> UpdateAsync(int id, T model);

        Task<IEnumerable<T>> GetByFilterAsync<U>(string columnName, U value);
    }
}
