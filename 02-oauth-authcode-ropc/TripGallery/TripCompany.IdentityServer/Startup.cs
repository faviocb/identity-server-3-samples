using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using TripCompany.IdentityServer.Config;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Services.Default;

[assembly: OwinStartup(typeof(TripCompany.IdentityServer.Startup))]

namespace TripCompany.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {



            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.Map("/identity", idsrvApp =>

                    {
                        
                        var corsPolicyService = new DefaultCorsPolicyService()  //TODO FAVIO -> use other policy that is included in the "End" folder, because the one used here accepts any origin (not just our angular app)
                        {
                            AllowAll = true
                        };



                        var idServerServiceFactory = new IdentityServerServiceFactory()
                        .UseInMemoryClients(Clients.Get())
                        .UseInMemoryScopes(Scopes.Get())
                        .UseInMemoryUsers(Users.Get());

                        idServerServiceFactory.CorsPolicyService = new 
                            Registration<IdentityServer3.Core.Services.ICorsPolicyService>(corsPolicyService);

                        var options = new IdentityServerOptions
                        {
                            Factory = idServerServiceFactory,
                            SiteName = "TripCompany Security Token service",
                            IssuerUri = TripGallery.Constants.TripGalleryIssuerUri,
                            PublicOrigin = TripGallery.Constants.TripGallerySTSOrigin ,
                            SigningCertificate = LoadCertificate()
                        };


                        idsrvApp.UseIdentityServer(options);

                    }
                );
        
        }

        X509Certificate2 LoadCertificate()
        { 
            return  new X509Certificate2(
                    string.Format(@"{0}\Certificates\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory),
                    "idsrv3test"
                );
        }
    
    }
}
