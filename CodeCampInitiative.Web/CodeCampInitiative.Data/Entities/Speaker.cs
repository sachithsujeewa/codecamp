namespace CodeCampInitiative.Data.Entities
{
    /// <summary>
    /// The speaker entity
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Entities.EntityBase" />
    public class Speaker : EntityBase
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the company URL.
        /// </summary>
        /// <value>
        /// The company URL.
        /// </value>
        public string CompanyUrl { get; set; }

        /// <summary>
        /// Gets or sets the blog URL.
        /// </summary>
        /// <value>
        /// The blog URL.
        /// </value>
        public string BlogUrl { get; set; }

        /// <summary>
        /// Gets or sets the twitter.
        /// </summary>
        /// <value>
        /// The twitter.
        /// </value>
        public string Twitter { get; set; }

        /// <summary>
        /// Gets or sets the git hub.
        /// </summary>
        /// <value>
        /// The git hub.
        /// </value>
        public string GitHub { get; set; }
    }
}
