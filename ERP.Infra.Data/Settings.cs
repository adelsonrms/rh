using System.Configuration;

namespace RH.Infra.Data
{
    public static class AppConfig
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["TPAContextConnStr"].ConnectionString;
    }
}