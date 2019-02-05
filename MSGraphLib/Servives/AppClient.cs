using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MSGraphApi.Clients
{
    public  class AppClient
    {
        public AppClient()
        {
            AppId = "ac6aad15-111e-4f79-a816-64c85dba0736";
            AppSecret = "pzmLMTIM8_%hjiyXH6615^_";
            Scopes = "https://graph.microsoft.com/.default";
            Grant_Type = "client_credentials";
            TenanId = "tecnun.com.br";

        }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string Resoruce { get; set; }
        public string Scopes { get; set; }
        public string Grant_Type { get; set; }
        public string TenanId { get; set; }
        public string QueryString => this.ToString();
        public FormUrlEncodedContent ContentBody => ConvertToFormBase(ToString());
        public override string ToString()
        {
            return string.Format("client_id={0}&scope={1}&client_secret={2}&grant_type={3}", AppId, Scopes, AppSecret, Grant_Type);
        }
        private FormUrlEncodedContent ConvertToFormBase(string parameters)
        {
            var pairs = new List<KeyValuePair<string, string>>();

            foreach (var x in parameters.Split("&".ToCharArray()).ToList())
            {
                var arr = x.Split("=".ToCharArray());
                pairs.Add(new KeyValuePair<string, string>(arr[0], arr[1]));
            }
            return new FormUrlEncodedContent(pairs);
        }
    }
}
