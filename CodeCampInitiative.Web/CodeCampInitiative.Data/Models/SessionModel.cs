namespace CodeCampInitiative.Data.Models
{
    /// <summary>
    /// View model for the session entity
    /// </summary>
    public class SessionModel
    {
        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        public string Id { get; set; }

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
        public SpeakerModel Speaker { get; set; }
    }
}
