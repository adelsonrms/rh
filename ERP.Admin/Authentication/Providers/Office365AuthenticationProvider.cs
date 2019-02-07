using ERP.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;

namespace Identity.Authentication.Providers
{
    public static class Office365AuthenticationProvider
    {
        // ID do Aplicativo cadastrado no Azure
        private static string clientId = ConfigurationManager.AppSettings["ClientId"];
        
        // RedirectUri : É a URL que será redirecionada após o login
        private static string redirectUrl = ConfigurationManager.AppSettings["redirectUrl"];
        
        // Tenant ID : É o ID da empresa
        private static string tenant = ConfigurationManager.AppSettings["Tenant"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["PostLogoutRedirectUri"];
        private static string redirectUri = ConfigurationManager.AppSettings["RedirectUri"];
        
        // Authority : É a url do serviço de autenticação da Microsoft. Ex : https://login.microsoftonline.com/contoso.onmicrosoft.com
        private static string authority = String.Format(System.Globalization.CultureInfo.InvariantCulture, ConfigurationManager.AppSettings["Authority"], tenant);

        public static IAppBuilder UseOffice365ExternalAuthentication(this IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = SettingsHelper.ClientSecret,
                Authority = SettingsHelper.Authority,
                PostLogoutRedirectUri = postLogoutRedirectUri,
                RedirectUri = redirectUri,
                AuthenticationMode = AuthenticationMode.Passive,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    RedirectToIdentityProvider = (context) =>
                    {
                        context.ProtocolMessage.DomainHint = "tecnun.com.br";
                        return Task.FromResult(0);
                    },
                    AuthenticationFailed = (context) =>
                    {

                        var erro = context.Exception.Message;


                        if (erro.StartsWith("OICE_20004") || erro.Contains("IDX10311"))
                        {
                            context.SkipToNextMiddleware();
                            return Task.FromResult(0);
                        }

                        if (erro.Contains("AADSTS50105"))
                        {
                            erro = "Office 365 Login - Acesso Negado à Aplicação";
                        }

                        context.HandleResponse();
                        context.Response.Redirect("/Account/ErrorLogin/?mensagem=" + erro);
                        return Task.FromResult(0);
                    }
                }
            });
            return app;
        }


        public static IAppBuilder UseTecnunAuthServer(this IAppBuilder app)
        {

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "TECUNU.ERP.RH.WebApp",
                ClientSecret = "secret",
                Authority = "http://localhost:5000/", //"https://login.tecnun.com.br",
                RedirectUri = "https://localhost:44379/", //"https://rh.tecnun.com.br",
                RequireHttpsMetadata = false,
                ResponseType = "code id_token",
                Scope = "api1 openid profile",
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    RedirectToIdentityProvider = (context) =>
                    {
                        context.ProtocolMessage.DomainHint = "tecnun.com.br";
                        return Task.FromResult(0);
                    },
                    AuthenticationFailed = (context) =>
                    {

                        var erro = context.Exception.Message;


                        if (erro.StartsWith("OICE_20004") || erro.Contains("IDX10311"))
                        {
                            context.SkipToNextMiddleware();
                            return Task.FromResult(0);
                        }

                        if (erro.Contains("AADSTS50105"))
                        {
                            erro = "Office 365 Login - Acesso Negado à Aplicação";
                        }

                        context.HandleResponse();
                        context.Response.Redirect("/Account/ErrorLogin/?mensagem=" + erro);
                        return Task.FromResult(0);
                    }
                }
            });
            return app;
        }


    }
}