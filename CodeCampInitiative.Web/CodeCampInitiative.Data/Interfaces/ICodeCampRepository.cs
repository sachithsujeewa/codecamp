namespace CodeCampInitiative.Data.Interfaces
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// this interface is used to DI code camp repository to code camp service
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.IEntityRepository{CodeCampInitiative.Data.Entities.CodeCamp}" />
    public interface ICodeCampRepository : IEntityRepository<CodeCamp>
    {
        /// <summary>
        /// Gets the camp by moniker asynchronous.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="includeSessions">if set to <c>true</c> [include sessions].</param>
        /// <returns>code camp object</returns>
        Task<CodeCamp> GetCampByMonikerAsync(string moniker, bool includeSessions = false);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="includeSessions">if set to <c>true</c> [include sessions].</param>
        /// <returns></returns>
        Task<IEnumerable<CodeCamp>> GetAllAsync(bool includeSessions = false);
    }
}