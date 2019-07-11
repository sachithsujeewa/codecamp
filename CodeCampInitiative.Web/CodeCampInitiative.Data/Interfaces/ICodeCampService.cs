namespace CodeCampInitiative.Data.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// interface for code camp service
    /// </summary>
    public interface ICodeCampService
    {
        /// <summary>
        /// Gets the code camps.
        /// </summary>
        /// <param name="includeSessions">if set to <c>true</c> [include sessions].</param>
        /// <returns></returns>
        Task<IEnumerable<CodeCampModel>> GetCodeCamps(bool includeSessions);

        /// <summary>
        /// Gets the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns></returns>
        Task<CodeCampModel> GetCodeCamp(string moniker);

        /// <summary>
        /// Updates the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="codeCampModel">The code camp model.</param>
        /// <returns></returns>
        Task<CodeCampModel> UpdateCodeCamp(string moniker, CodeCampModel codeCampModel);

        /// <summary>
        /// Adds the new code camp.
        /// </summary>
        /// <param name="codeCampModel">The code camp model.</param>
        /// <returns></returns>
        Task<CodeCampModel> AddNewCodeCamp(CodeCampModel codeCampModel);

        /// <summary>
        /// Deletes the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns></returns>
        Task DeleteCodeCamp(string moniker);
    }
}