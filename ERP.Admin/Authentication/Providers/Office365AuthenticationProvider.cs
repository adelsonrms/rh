using ERP.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using RH.UI;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;

namespace Identity.Authentication.Providers
{
    public static class Office365AuthenticationProvider
    {
        // Authority : É a url do serviço de autenticação da Microsoft. Ex : https://login.microsoftonline.com/contoso.onmicrosoft.com
        public static IAppBuilder UseOffice365ExternalAuthentication(this IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = AppConfig.AzureAppClient.ClientId,
                ClientSecret = AppConfig.AzureAppClient.ClientSecret,
                Authority = AppConfig.AzureAppClient.Authority,
                PostLogoutRedirectUri = AppConfig.AzureAppClient.PostLogoutRedirectUri,
                RedirectUri = AppConfig.AzureAppClient.RedirectUri,
                AuthenticationMode = AuthenticationMode.Passive,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    RedirectToIdentityProvider = (context) =>
                    {
                        context.ProtocolMessage.DomainHint = AppConfig.AzureAppClient.Domain;
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
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = AppConfig.AuthServerClient.ClientId,
                ClientSecret = AppConfig.AuthServerClient.ClientSecret,
                Authority = AppConfig.AuthServerClient.Authority,
                RedirectUri = AppConfig.AuthServerClient.RedirectUri,
                RequireHttpsMetadata = false,
                ResponseType = "code id_token",
                Scope = "openid profile api1"
            });
            return app;
        }
    }
}