using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRTourismApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false);
    }
}
