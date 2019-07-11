namespace CodeCampInitiative.Data.Repositories
{
    using Entities;
    using Interfaces;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// implement repository methods specialized to code camp domain 
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Repositories.EntityRepository{CodeCampInitiative.Data.Entities.CodeCamp}" />
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.ICodeCampRepository" />
    public class CodeCampRepository : EntityRepository<CodeCamp>, ICodeCampRepository
    {
        /// <summary>
        /// Gets the camp by moniker asynchronous.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="includeSessions">if set to <c>true</c> [include sessions].</param>
        /// <returns>code camp object</returns>
        public async Task<CodeCamp> GetCampByMonikerAsync(string moniker, bool includeSessions = false)
        {
            var query = Table.Include(c => c.Location);

            if (includeSessions)
            {
                query = query.Include(c => c.Sessions.Select(t => t.Speaker));
            }

            query = query.Where(c => c.Moniker == moniker);

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// overloaded base class method for support query string
        /// </summary>
        /// <param name="includeSessions">if set to <c>true</c> [include sessions].</param>
        /// <returns>list of code camp objects</returns>
        public async Task<IEnumerable<CodeCamp>> GetAllAsync(bool includeSessions = false)
        {
            var query = Table.Include(c => c.Location);

            if (includeSessions)
            {
                query = query.Include(c => c.Sessions.Select(t => t.Speaker));
            }

            return await query.ToListAsync();
        }
    }
}
