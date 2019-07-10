using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                cfg.CreateMap<CodeCamp, CodeCampModel>();
            });

            return config.CreateMapper();
        }
        
    }
}
