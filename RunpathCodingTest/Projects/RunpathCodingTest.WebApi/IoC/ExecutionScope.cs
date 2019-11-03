using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using RunpathCodingTest.WebApi.HttpClient;
using RunpathCodingTest.WebApi.Models.Builders;
using RunpathCodingTest.WebApi.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace RunpathCodingTest.WebApi.IoC
{
    public class ExecutionScope
    {
        public static Container Container { get; set; }

        public void Configure()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterForAssmebly(Container, typeof(IPhotoService).Assembly, "RunpathCodingTest.WebApi.Services");
            RegisterForAssmebly(Container, typeof(IAlbumModelBuilder).Assembly, "RunpathCodingTest.WebApi.Models.Builders");
            Container.RegisterSingleton<IPhotoRequestor>(() => new PhotoRequestor());
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(Container);

            Container.Verify();
        }

        private void RegisterForAssmebly(Container container, Assembly assembly, string nameSpace)
        {
            var registrations = assembly.GetExportedTypes()
                .Where(
                    type => type.Namespace.Contains(nameSpace)
                            && type.GetInterfaces().Any()
                            && !type.IsAbstract && !type.IsSubclassOf(typeof(Attribute))
                            && !type.IsEnum)
                .Select(type => new { Services = type.GetInterfaces(), Implementation = type });

            foreach (var registration in registrations)
            {
                foreach (var service in registration.Services)
                {
                    container.Register(service, registration.Implementation, Lifestyle.Scoped);
                }
            }
        }

        public void BeginScope()
        {
            AsyncScopedLifestyle.BeginScope(Container);
        }
    }
}