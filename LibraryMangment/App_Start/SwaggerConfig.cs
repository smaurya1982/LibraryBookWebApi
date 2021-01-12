using System.Web.Http;
using WebActivatorEx;
using LibraryMangment;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace LibraryMangment
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            //https://localhost:44306/swagger/ui/index
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                       
                        c.SingleApiVersion("v1", "LibraryMangment");

                        
                    })
                .EnableSwaggerUi(c =>
                    {
                      
                    });
        }
    }
}
