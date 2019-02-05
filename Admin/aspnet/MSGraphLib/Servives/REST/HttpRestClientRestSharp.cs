using MSGraphApi.Clients;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Shared.RestServices
{
    public class HttpRestClientRestSharp : IRestApiClient
    {
        RestClient client;
        public string EndPoint { get; set; }
        public HttpRestClientRestSharp(string endPoint)
        {
            EndPoint = endPoint;
            client = new RestClient(endPoint);
        }
        public async Task<TResponse> GetAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader) where TResponse : new()
        {
            return await ExecuteRequestAsync<TResponse>("GET", RequestHeader);
        }

        public async Task<TResponse> PostAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader,
            object body = null) where TResponse : new()
        {
            try
            {
                return await ExecuteRequestAsync<TResponse>("POST", RequestHeader, body);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<TResponse> getToken<TResponse>(AppClient app)
        {
            //Getting a token is rather simple
            //Using a class based variable is probably a good idea since this is only set once but remains constant
            //If this is not desired then the token will need to be carried via other methods
            //Reuse of this value will be necessary among all your calls
            //Use this method first because none of the other calls can work without your access toekn
           // RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();

            var client = new RestClient(EndPoint);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("content-type", "application/json");
            request.RequestFormat = DataFormat.Json;

            //request.AddHeader("authorization", string.Format("client_id:{0}, client_secret:{1}", app.AppId, app.AppSecret));
            //request.AddParameter("application/json", "{\n\"grant_type\":\"client_credentials\"\n}", ParameterType.RequestBody);

            request.AddParameter("application/json", "{\n\"grant_type\":\"" + app.Grant_Type + "\"\n}", ParameterType.RequestBody);
            request.AddParameter("application/json", "{\n\"client_id\":\"" + app.AppId + "\"\n}", ParameterType.RequestBody);
            request.AddParameter("application/json", "{\n\"scope\":\"" + app.Scopes+ "\"\n}", ParameterType.RequestBody);
            request.AddParameter("application/json", "{\n\"client_secret\":\"" + app.AppSecret + "\"\n}", ParameterType.RequestBody);



            IRestResponse response = client.Execute(request);

            var responseObject = ConvertResponseJSonToObject(response).ToObject<TResponse>();

            return await Task.FromResult(responseObject);

            //RootObject returnData = deserial.Deserialize<RootObject>(response);
            //if (returnData.data[0].access_token != null)
            //{
            //    access = returnData.data[0].access_token; //This correctly gets the Access Token. You should return this to a class variable so that all the  other functions can access it easily and you're not constantly passing along the variable through them.

            //}
        }

        private async Task<TResponse> ExecuteRequestAsync<TResponse>(string method,List<KeyValuePair<string, string>> RequestHeader,object body = null) where TResponse : new()
        {
            try
            {
                IRestRequest request = new RestRequest(EndPoint, GetMethod(), DataFormat.Json);
                IRestResponse<TResponse> res = new RestResponse<TResponse>();

                //Define os cabeçalhos do request, caso tenha
                if (RequestHeader!=null) { RequestHeader.ForEach(hdr => request.AddHeader(hdr.Key, hdr.Value)); }
                if (body != null){request.AddParameter("body", body, ParameterType.RequestBody);}

                //client.Authenticator = new HttpBasicAuthenticator("client-app", "secret");

                //**** Metodo Resposavel por enviar o Request Assincrono
                res = client.Execute<TResponse>(request);

                var responseObject = ConvertResponseJSonToObject(res).ToObject<TResponse>();
                return await Task.FromResult(responseObject);
                //C# 6.0 - Metodo Local. Visivel somente no escopo dessa função
                Method GetMethod() => method == "GET" ? Method.GET : Method.POST;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private JObject ConvertResponseJSonToObject(IRestResponse response)
        {
            string jsonContent = response.Content;
            JObject jsonObject = JObject.Parse(jsonContent);
            return jsonObject;
        }

        public void Dispose() {return;}
    }
}
