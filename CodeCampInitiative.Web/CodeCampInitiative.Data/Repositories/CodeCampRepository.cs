using CodeCampInitiative.Data.Entities;
using CodeCampInitiative.Data.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Repositories
{
    public class CodeCampRepository : EntityRepository<CodeCamp>, ICodeCampRepository
    {
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
