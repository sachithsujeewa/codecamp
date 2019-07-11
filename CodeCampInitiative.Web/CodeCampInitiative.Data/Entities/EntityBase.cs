
namespace CodeCampInitiative.Data.Entities
{
    using Interfaces;

    /// <summary>
    /// Base entity for all the data entities. used to keep common properties
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.IEntityBase" />
    public class EntityBase : IEntityBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}
