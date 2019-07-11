using CodeCampInitiative.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Interfaces
{
    public interface ISessionService
    {
        /// <summary>
        /// Gets the code camps.
        /// </summary>
        /// <param name="moniker"></param>
        /// <param name="includeSpeakers"></param>
        /// <returns>list of code camp models</returns>
        Task<IEnumerable<SessionModel>> GetSessions(string moniker, bool includeSpeakers = false);

        /// <summary>
        /// Gets the session by moniker.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="includeSpeaker">if set to <c>true</c> [include speaker].</param>
        /// <returns></returns>
        Task<SessionModel> GetSessionByMoniker(string moniker, int id, bool includeSpeaker = false);
    }
}