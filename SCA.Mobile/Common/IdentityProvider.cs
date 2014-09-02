using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
﻿using System.DirectoryServices.AccountManagement;


namespace SCA.Mobile.API
{

    public interface ILoginProvider
    {
        bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity);
    }

    public class DomainUserLoginProvider : ILoginProvider
    {
        public bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity)
        {
            bool isValid = true;//  pc.ValidateCredentials(userName, password);
            if (isValid)
            {
                identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            }
            else
            {
                identity = null;
            }

            return isValid;
         //   using (var pc = new PrincipalContext(ContextType.Domain, _domain))
          //  {
                
          //  }
        }

        public DomainUserLoginProvider(string domain)
        {
            _domain = domain;
        }

        private readonly string _domain;
    }

    public class LocalUserLoginProvider : ILoginProvider
    {
        public bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity)
        {
            using (var pc = new PrincipalContext(ContextType.Machine))
            {
                bool isValid = pc.ValidateCredentials(userName, password);
                if (isValid)
                {
                    identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                }
                else
                {
                    identity = null;
                }

                return isValid;
            }
        }
    }
}