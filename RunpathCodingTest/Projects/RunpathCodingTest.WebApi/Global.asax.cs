using System.Web.Http;
using RunpathCodingTest.WebApi.IoC;

namespace RunpathCodingTest.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var executionScope = new ExecutionScope();
            executionScope.Configure();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
