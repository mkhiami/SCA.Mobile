using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SCA.Mobile.API.Common;
using SCA.Mobile.API.Providers;
using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SCA.Mobile.API
{
    public partial class Startup
    {



        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions();
        }


        public static void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
     
        private static Autofac.IContainer RegisterServices()
        {
            var builder = new ContainerBuilder();


            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(t => t.Name.EndsWith("Controller"))
                .AsSelf();

            builder.RegisterInstance(new DomainUserLoginProvider("unevol.cu"))
                .As<ILoginProvider>()
                .SingleInstance();

            //builder.RegisterType<LocalUserLoginProvider>()
            //    .As<ILoginProvider>()
            //    .SingleInstance();

            return builder.Build();
        }

        public static void ConfigureComposition(HttpConfiguration config)
        {
            IContainer container = RegisterServices();
            config.DependencyResolver = new AutoFacDependencyResolver(container);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {


            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new LowercaseContractResolver();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

    }
}
