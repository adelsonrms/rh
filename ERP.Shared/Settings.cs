using System.Configuration;

namespace RH.Shared.Settings
{
    public static class Settings
    {
        public static string AmbienteDeExecucao() => ConfigurationManager.AppSettings["TPAContextConnStr"];
    }
}
