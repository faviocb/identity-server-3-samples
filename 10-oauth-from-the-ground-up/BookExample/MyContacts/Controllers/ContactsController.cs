using MyContacts.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MyContacts.Controllers
{



    public class ContactsController : ApiController
    {
        [ClaimsPrincipalPermission(SecurityAction.Demand, Operation = "Get", Resource = "Contacts")]
        public IEnumerable<MailingContact> Get()
        {
            return Contact.GenerateContacts()
            .Where(c => c.Owner == User.Identity.Name)
            .Select(c => new MailingContact()
            {
                Name = c.Name,
                Email = c.Email
            }).ToList();
        }
    }



}
