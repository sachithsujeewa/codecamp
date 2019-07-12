namespace CodeCampInitiative.Data.Repositories
{
    using Entities;
    using Interfaces;

    /// <summary>
    /// implement repository methods specialized to Session domain 
    /// </summary>
    /// <seealso cref="CodeCamp" />
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.ICodeCampRepository" />
    public class SpeakerRepository : EntityRepository<Speaker>, ISpeakerRepository
    {
    }
}
