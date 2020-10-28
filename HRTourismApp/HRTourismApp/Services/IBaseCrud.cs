using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRTourismApp.LocalDatabase
{
    public interface IBaseCrud<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetItemAsync(string id);
        Task<int> SaveAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(T item);
    }
}
