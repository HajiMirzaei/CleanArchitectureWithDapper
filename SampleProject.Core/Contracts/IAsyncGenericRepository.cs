using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleProject.Core.Contracts
{
    public interface IAsyncGenericRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> Query(string where);
    }
}
