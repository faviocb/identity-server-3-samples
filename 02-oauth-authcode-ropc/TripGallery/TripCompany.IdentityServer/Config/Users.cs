using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCompany.IdentityServer.Config
{
    public class Users
    {

        public static List<InMemoryUser> Get()
        {

            return new List<InMemoryUser>()
            {
                new InMemoryUser
                {
                    Username = "john",
                    Password = "secretpwd",
                    Subject = "5AA8AA30-6BD3-4FCC-A81B-C3CD5B8C116A"
                }
                ,
                new InMemoryUser
                {
                    Username = "luis",
                    Password = "secretsua",
                    Subject = "27065FB5-282E-4C16-A79F-DAB1CD0BF1E6"
                }

            };
        
        }
    }
}