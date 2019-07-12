namespace CodeCampInitiative.Library.Mapper
{
    using AutoMapper;
    using Data.Entities;
    using Data.Models;

    /// <summary>
    /// use to map database entities to view models and vice versa
    /// </summary>
    public static class MapperConfig
    {
        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <returns></returns>
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<CodeCamp, CodeCampModel>().ReverseMap();
                cfg.CreateMap<Session, SessionModel>().ReverseMap();
                cfg.CreateMap<Speaker, SpeakerModel>().ReverseMap();
            });

            return config.CreateMapper();
        }

    }
}
