using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MyContacts.Infrastructure
{
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {

            string resource = context.Resource.First().Value;
            string action = context.Action.First().Value;

            if (action == "Get" && resource == "Contacts")
            {
                ClaimsIdentity id = (context.Principal.Identity as ClaimsIdentity);

                if (!id.IsAuthenticated)
                    return false;

                return (id.Claims.Any(c => c.Type ==  ConfigurationManager.AppSettings["UrlMyContacts-OAuth20-Scope"]  && c.Value.Equals("Read.Contacts")));
            }
            return false;
        }
    }
}