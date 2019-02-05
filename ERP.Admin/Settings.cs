using System.Configuration;

namespace RH.UI
{
    public static class AppConfig
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["TPAContextConnStr"].ConnectionString;
    }
}