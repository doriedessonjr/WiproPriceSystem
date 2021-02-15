using Autofac;
using Autofac.Integration.WebApi;
using WiproPriceSystem.Ioc;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace WiproPriceSystem.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            ContainerBuilder _containerBuilder = ContainerConfig.CreateBuilder();
            _containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var _container = _containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);

            //Retornar Json
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Evitar erro de formatação de loop
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
