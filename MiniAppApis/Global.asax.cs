using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MiniAppApis
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            try
            {
                //注册log4net
                log4net.Config.XmlConfigurator.Configure();
            }
            catch { }
        }
    }
}
