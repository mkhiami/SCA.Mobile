using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using SCA.Mobile.API.Common;
using System.Web.Http;

[assembly: OwinStartup(typeof(SCA.Mobile.API.Startup))]
namespace SCA.Mobile.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //Log trafic using Log4Net
            app.Use(typeof(Logging));



            var config = new HttpConfiguration();
            ConfigureComposition(config);

            ConfigureWebApi(config);
            app.UseWebApi(config);
        }
    }
}
