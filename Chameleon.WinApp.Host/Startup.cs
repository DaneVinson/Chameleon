using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Chameleon.WinApp.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.EnableCors(new EnableCorsAttribute(
                                                "*", 
                                                "*", 
                                                "GET, POST, OPTIONS, PUT, DELETE"));
            httpConfiguration.Routes.MapHttpRoute(
                                        name: "FormsRoute",
                                        routeTemplate: "api/{controller}/{formType}",
                                        defaults: new { formType = RouteParameter.Optional });
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}
