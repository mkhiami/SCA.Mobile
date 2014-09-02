using log4net;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using SCA.Mobile.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;

namespace SCA.Mobile.API.Controllers
{
    public class AccountController : ApiController
    {
        SCA.Mobile.Data.TaskModuleEntities db = new Data.TaskModuleEntities();
     

        public AccountController()
        {
            HttpContext.Current.Response.SuppressFormsAuthenticationRedirect = true;
        }



        [AllowAnonymous]
        [HttpPost, Route("Token")]
        [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
        public IHttpActionResult Token(LoginViewModel login)
        {
            Log.DebugFormat("Entering Token(): User={0}", login.UserName);

            if (!ModelState.IsValid)
            {
                Log.Debug("Leaving Token(): Bad request");
                return this.BadRequestError(ModelState);
            }

            ClaimsIdentity identity;

            if (!_loginProvider.ValidateCredentials(login.UserName, login.Password, out identity))
            {
                Log.Debug("Leaving Token(): Incorrect user or password");
                return BadRequest("Incorrect user or password");
            }

            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(60));
            var ticker = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
            Log.Debug("Leaving Token()");

            return Ok(new LoginAccessViewModel
            {
                UserName = login.UserName,
                Issued = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(60),
                AccessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket)
            });
        }

        [HttpGet]
        [Route("account/profile")]
        [Authorize]
        public HttpResponseMessage Profile()
        {
            int userdid= int.Parse(User.Identity.Name.ToLower().Replace("sca",""));
            
             Data.User user =      db.Users.FirstOrDefault(u => u.ID == userdid);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(user, Configuration.Formatters.JsonFormatter)
            };
        }



        public AccountController(ILoginProvider loginProvider)
        {
            Log.Debug("Entering AccountController()");
            _loginProvider = loginProvider;
        }

        private readonly ILoginProvider _loginProvider;
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountController));
   
    }
}
