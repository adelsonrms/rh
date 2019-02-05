using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ERP.Authentication
{
    public  class SettingsHelper
    {

        public static string GraphResourceId { get; } = "https://graph.microsoft.com";

        public static string AADInstance { get; } = ConfigurationManager.AppSettings["ida:AADInstance"];
        public static string ClientId { get; } = ConfigurationManager.AppSettings["ida:ClientId"];
        public static string ClientSecret { get; } = ConfigurationManager.AppSettings["ida:ClientSecret"];
        public static string TenantId { get; } = ConfigurationManager.AppSettings["ida:TenantId"];

        public static string Authority { get; } = AADInstance + TenantId;
    }
}