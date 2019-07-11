using CodeCampInitiative.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Interfaces
{
    public interface ICodeCampService
    {
        Task<IEnumerable<CodeCampModel>> GetCodeCamps(bool includeSessions);
        Task<CodeCampModel> GetCodeCamp(string moniker);
        Task<CodeCampModel> UpdateCodeCamp(string moniker, CodeCampModel codeCampModel);
        Task<CodeCampModel> AddNewCodeCamp(CodeCampModel codeCampModel);
        Task DeleteCodeCamp(string moniker);
    }
}