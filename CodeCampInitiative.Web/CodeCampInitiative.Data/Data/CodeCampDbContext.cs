namespace CodeCampInitiative.Data.Data
{
    using Entities;
    using System.Data.Entity;

    /// <summary>
    /// Context class for code camp project 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class CodeCampDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the code camps.
        /// </summary>
        /// <value>
        /// The code camps.
        /// </value>
        public DbSet<CodeCamp> CodeCamps { get; set; }

        /// <summary>
        /// Gets or sets the speakers.
        /// </summary>
        /// <value>
        /// The speakers.
        /// </value>
        public DbSet<Speaker> Speakers { get; set; }

        /// <summary>
        /// Gets or sets the sessions.
        /// </summary>
        /// <value>
        /// The sessions.
        /// </value>
        public DbSet<Session> Sessions { get; set; }
    }
}
