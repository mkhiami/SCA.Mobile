using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SCA.Mobile.API
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        
        public LowercaseContractResolver()
        {
            IgnoreSerializableAttribute = true;
        }
        protected override string ResolvePropertyName(string propertyName)
        {
            IgnoreSerializableAttribute = true;

            return propertyName.ToLower();
        }
    }



    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var serializerSettings =  GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            var contractResolver =  (DefaultContractResolver)serializerSettings.ContractResolver;
            contractResolver.IgnoreSerializableAttribute = true;
            
            JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings();

            jSettings.ContractResolver = new LowercaseContractResolver();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;

           

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
