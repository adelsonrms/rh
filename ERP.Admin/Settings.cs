using System.Configuration;

namespace RH.UI
{
    public static class AppConfig
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["TPAContextConnStr"].ConnectionString;

        public static class AuthServerClient
        {
            public static string ClientId = ConfigurationManager.AppSettings["IdSrv:ClientId"];
            public static string ClientSecret => ConfigurationManager.AppSettings["IdSrv:ClientSecret"];
            public static string RedirectUri = ConfigurationManager.AppSettings["IdSrv:RedirectUri"];
            public static string Authority = ConfigurationManager.AppSettings["IdSrv:Authority"];
            public static string PostLogoutRedirectUri = ConfigurationManager.AppSettings["IdSrv:PostLogoutRedirectUri"];
        }
        public static class AzureAppClient
        {
            public static string ClientId  => ConfigurationManager.AppSettings["ida:ClientId"];
            public static string ClientSecret => ConfigurationManager.AppSettings["ida:ClientSecret"];
            public static string RedirectUri => ConfigurationManager.AppSettings["ida:RedirectUri"];
            public static string RedirectUriDev => ConfigurationManager.AppSettings["ida:RedirectUriDev"];
            
            public static string Authority  => ConfigurationManager.AppSettings["ida:Authority"] + "/" + Domain;
            public static string PostLogoutRedirectUri => ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
            public static string Domain => ConfigurationManager.AppSettings["ida:Domain"];
        }
    }

    public  interface IAuthClient
    {
            string ClientId { get; set; }
            string ClientSecret { get; set; }
            string RedirectUri { get; set; }
            string Authority { get; set; }
            string PostLogoutRedirectUri { get; set; }
    }
}