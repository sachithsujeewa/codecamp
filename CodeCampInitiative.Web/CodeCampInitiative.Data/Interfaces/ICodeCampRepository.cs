using CodeCampInitiative.Data.Entities;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Interfaces
{
    public interface ICodeCampRepository : IEntityRepository<CodeCamp>
    {
        Task<CodeCamp> GetCampByMonikerAsync(string moniker, bool includeTalks = false);
    }
}