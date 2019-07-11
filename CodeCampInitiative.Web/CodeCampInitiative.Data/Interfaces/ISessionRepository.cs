namespace CodeCampInitiative.Data.Interfaces
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implement session specific repository methods
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.IEntityRepository{CodeCampInitiative.Data.Entities.Session}" />
    public interface ISessionRepository : IEntityRepository<Session>
    {
        /// <summary>
        /// Gets the sessions by moniker asynchronous.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="includeSpeakers">if set to <c>true</c> [include speakers].</param>
        /// <returns></returns>
        Task<IEnumerable<Session>> GetSessionsByMonikerAsync(string moniker, bool includeSpeakers = false);

        /// <summary>
        /// Gets the session by moniker asynchronous.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="includeSpeakers">if set to <c>true</c> [include speakers].</param>
        /// <returns></returns>
        Task<Session> GetSessionByMonikerAsync(string moniker, int id, bool includeSpeakers = false);
    }
}