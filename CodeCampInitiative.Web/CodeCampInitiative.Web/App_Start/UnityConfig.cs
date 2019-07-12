using CodeCampInitiative.Data.Interfaces;
using CodeCampInitiative.Data.Repositories;
using CodeCampInitiative.Library.Mapper;
using CodeCampInitiative.Library.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CodeCampInitiative.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ICodeCampRepository, CodeCampRepository>();
            container.RegisterInstance(MapperConfig.GetMapper());
            container.RegisterType<ICodeCampService, CodeCampService>();
            container.RegisterType<ISessionRepository, SessionRepository>();
            container.RegisterType<ISpeakerRepository, SpeakerRepository>();
            container.RegisterType<ISessionService, SessionService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}