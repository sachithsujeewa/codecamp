using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Repositories
{
    using Entities;
    using Interfaces;

    /// <summary>
    /// implement repository methods specialized to Session domain 
    /// </summary>
    /// <seealso cref="CodeCamp" />
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.ICodeCampRepository" />
    public class SessionRepository : EntityRepository<Session>, ISessionRepository
    {
        /// <summary>
        /// Gets the sessions by moniker asynchronous.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="includeSpeakers"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Session>> GetSessionsByMonikerAsync(string moniker, bool includeSpeakers = false)
        {
            IQueryable<Session> query = Table;

            if (includeSpeakers)
            {
                query = query
                    .Include(t => t.Speaker);
            }

            // Add Query
            query = query
                .Where(t => t.CodeCamp.Moniker == moniker)
                .OrderByDescending(t => t.Title);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets the session by moniker asynchronous.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="includeSpeakers">if set to <c>true</c> [include speakers].</param>
        /// <returns></returns>
        public async Task<Session> GetSessionByMonikerAsync(string moniker, int id, bool includeSpeakers = false)
        {
            IQueryable<Session> query = Table;

            if (includeSpeakers)
            {
                query = query
                    .Include(t => t.Speaker);
            }

            // Add Query

            return await query
                .Where(t => t.CodeCamp.Moniker == moniker)
                .Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
