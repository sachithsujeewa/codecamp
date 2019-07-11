namespace CodeCampInitiative.Data.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Code camp class
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Entities.EntityBase" />
    public class CodeCamp : EntityBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the moniker.
        /// </summary>
        /// <value>
        /// The moniker.
        /// </value>
        public string Moniker { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public DateTime EventDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length { get; set; } = 1;

        /// <summary>
        /// Gets or sets the sessions.
        /// </summary>
        /// <value>
        /// The sessions.
        /// </value>
        public ICollection<Session> Sessions { get; set; }
    }
}
