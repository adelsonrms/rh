using MSGraphService.RestServices.Clients;
using System;
using System.Collections.Generic;
using System.IO;

namespace MSGraphService.RestServices.Auth
{
    public class AccessTokenConfig
    {
        public AccessTokenConfig(){}

        static AccessTokenConfig Instance()
        {
            return new AccessTokenConfig();
        }

        private static string ObtemToken()
        {
            try
            {
                string file = Instance().GetType().Assembly.Location;

                if (File.Exists(file))
                {
                    var fileToken = GetFileToken();

                    if (File.Exists(fileToken))
                    {
                        var leitura = File.OpenText(fileToken);
                        var token = leitura.ReadToEnd();
                        leitura.Close();
                        return token;
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Error - " + ex.Message;
            }
        }
        private static void SalvarToken(string token)
        {
            try
            {
                var fileToken = GetFileToken();
                File.Delete(fileToken);
                var arquivo = File.CreateText(fileToken);
                arquivo.Write(token);
                arquivo.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        private static string GetFileToken()
        {
            string fileToken = string.Empty;
            string file = Instance().GetType().Assembly.Location;

            if (File.Exists(file))
            {
                var diretorio = new FileInfo(file).Directory.FullName;
                fileToken = Path.Combine(diretorio, "token.txt");
            }

            return fileToken;
        }
        public static AccessToken AccessToken { get; set; }
        public static AccessToken GetAccessToken(AppClient appClient)
        {
            AccessToken result = new AccessToken();

            result.access_token = ObtemToken();
            if (!string.IsNullOrEmpty(result.access_token)) { return result;}

            try
            {
                using (var client = new RESTService<HttpRestClientRestSharp>(string.Format("https://login.microsoftonline.com/{0}/oauth2/v2.0/token", appClient.TenanId)))
                {
                    client.AddHeader("Content-Type", "application /x-www-form-urlencoded");
                    var response = client.Post<AccessToken>(appClient.QueryString).Result;
                    result = response.Data;
                    SalvarToken(result.access_token);
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

