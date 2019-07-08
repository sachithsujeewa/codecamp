using CodeCampInitiative.Data.Entities;
using System.Data.Entity;

namespace CodeCampInitiative.Data.Data
{
    public class CodeCampDbContext : DbContext
    {
        public DbSet<CodeCamp> CodeCamps { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
