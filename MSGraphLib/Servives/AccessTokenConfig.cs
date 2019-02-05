using MSGraph.Services;
using MSGraphApi.Clients;
using System;
using System.Collections.Generic;

namespace ERP.Shared.RestServices
{
    public static class AccessTokenConfig
    {
        public static AccessToken AccessToken { get; set; }
        public static AccessToken GetAccessToken(AppClient appClient)
        {
            AccessToken result = new AccessToken();
            try
            {
                using (var client = new RESTService<HttpRestClientRestSharp>(string.Format("https://login.microsoftonline.com/{0}/oauth2/v2.0/token", appClient.TenanId)))
                {
                    var Headers = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("Content-Type", "application /x-www-form-urlencoded") };
                    result = client.Post<AccessToken>(Headers, appClient.QueryString).Result;
                }
            }
            catch (Exception ex)
            {
                result.access_token = "Excepion : " + ex.Message;
            }
            return result;
        }
    }
}
