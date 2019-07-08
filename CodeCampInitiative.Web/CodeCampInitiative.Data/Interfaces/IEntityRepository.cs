using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Interfaces
{
    public interface IEntityRepository<T> where T : IEntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        Task SaveAsync();
    }
}
