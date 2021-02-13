using System.Web.Http;
using Swashbuckle.Application;
using System.Linq;
using System.Web;
using WiproPriceSystem.Api.App_Start;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WiproPriceSystem.Api.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WiproPriceSystem");
                    //c.IncludeXmlComments(GetXmlCommentsPath());
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    })
                    .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
