using CodeCampInitiative.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Interfaces
{
    public interface ICodeCampRepository : IEntityRepository<CodeCamp>
    {
        Task<CodeCamp> GetCampByMonikerAsync(string moniker, bool includeSessions = false);
        Task<IEnumerable<CodeCamp>> GetAllAsync(bool includeSessions = false);
    }
}