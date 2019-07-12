namespace CodeCampInitiative.Data.Interfaces
{
    using Entities;

    /// <summary>
    /// Implement session specific repository methods
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.IEntityRepository{CodeCampInitiative.Data.Entities.Session}" />
    public interface ISpeakerRepository : IEntityRepository<Speaker>
    {
    }
}