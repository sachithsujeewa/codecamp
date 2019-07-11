namespace CodeCampInitiative.Data.Entities
{
    /// <summary>
    /// The Session entity
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Entities.EntityBase" />
    public class Session : EntityBase
    {
        /// <summary>
        /// Gets or sets the code camp.
        /// </summary>
        /// <value>
        /// The code camp.
        /// </value>
        public CodeCamp CodeCamp { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        /// <value>
        /// The abstract.
        /// </value>
        public string Abstract { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the speaker.
        /// </summary>
        /// <value>
        /// The speaker.
        /// </value>
        public Speaker Speaker { get; set; }
    }
}
