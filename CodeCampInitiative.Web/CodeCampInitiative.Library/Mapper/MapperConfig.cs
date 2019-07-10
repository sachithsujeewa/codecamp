using AutoMapper;
using CodeCampInitiative.Data.Entities;
using CodeCampInitiative.Data.Models;

namespace CodeCampInitiative.Library.Mapper
{
    public static class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<CodeCamp, CodeCampModel>().ReverseMap();
                cfg.CreateMap<Session, SessionModel>();
                cfg.CreateMap<Speaker, SpeakerModel>();
            });

            return config.CreateMapper();
        }

    }
}
