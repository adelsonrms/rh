using Identity.Authentication.Providers;
using Microsoft.Owin;
using Owin;
using RH.Infra.Data.DBContexts;

[assembly: OwinStartup(typeof(ERP.Presentation.Api.App_Start.Startup))]

namespace ERP.Presentation.Api.App_Start
{
    public partial class Startup
    {
        /// <summary>
        /// Configure OWIN to use OpenIdConnect 
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //Middlearw para autenticação via Forms
            app.UseFormsAuthentication();

            app.UseOffice365ExternalAuthentication();
            app.UseTecnunAuthServer();

        }
       
    }
}


