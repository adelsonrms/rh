using MSGraphService.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MSGraphService.RestServices.Clients
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
        public async Task<Response> GetAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader) where TResponse : new()
        {
            return await ExecuteRequestAsync<TResponse>("GET", RequestHeader);
        }
        public async Task<Response> PostAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader,object body = null) where TResponse : new()
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
        private async Task<Response> ExecuteRequestAsync<TResponse>(string method,List<KeyValuePair<string, string>> RequestHeader,object body = null) where TResponse : new()
        {
            try
            {
                IRestRequest request = new RestRequest(EndPoint, GetMethod(), DataFormat.Json);
                IRestResponse<TResponse> response = new RestResponse<TResponse>();

                //Define os cabeçalhos do request, caso tenha
                if (RequestHeader!=null) { RequestHeader.ForEach(hdr => request.AddHeader(hdr.Key, hdr.Value)); }
                if (body != null){request.AddParameter("body", body, ParameterType.RequestBody);}

                //**** Metodo Resposavel por enviar o Request Assincrono
                response = client.Execute<TResponse>(request);

                var ResponseObject = JSerializer.ConvertStringToObject<TResponse>(response.Content);

                return await Task.FromResult(
                    new Response()
                    {
                        Status = response.StatusCode,
                        Description = response.StatusDescription,
                        Data = ResponseObject,
                        HttpResponse = response
                    });

                //C# 6.0 - Metodo Local. Visivel somente no escopo dessa função
                Method GetMethod() => method == "GET" ? Method.GET : Method.POST;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void Dispose() {return;}
    }

    public class Response
    {
        public HttpStatusCode Status { get; internal set; }
        public string Description { get; internal set; }
        public dynamic Data { get; internal set; }
        public dynamic HttpResponse { get; internal set; }
    }
}
