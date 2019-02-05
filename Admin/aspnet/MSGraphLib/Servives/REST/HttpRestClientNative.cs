using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ERP.Shared.RestServices
{
    public class HttpRestClientNative : IRestApiClient
    {
        private readonly HttpClient client;
        public string EndPoint { get; set; }
        public HttpRestClientNative(string endPoint)
        {
            var url = new Uri(endPoint);

            EndPoint = endPoint;
            client = new HttpClient();
        }
        public async Task<TResponse> GetAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader) where TResponse : new() => await ExecuteRequestAsync<TResponse>("GET", RequestHeader);
        public async Task<TResponse> PostAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader, object body) where TResponse : new() => await ExecuteRequestAsync<TResponse>("POST", RequestHeader, body);
        /// <summary>
        /// Envia o Request para o servidor informando o tipo
        /// </summary>
        /// <typeparam name="TResponse">Objeto de retorno a ser deserializado do json</typeparam>
        /// <param name="method">Metodo do Request</param>
        /// <param name="RequestHeader">Cabeçalhos do Request</param>
        /// <param name="body">Conteudo do corpo do request. No caso do POST</param>
        /// <returns></returns>
        private async Task<TResponse> ExecuteRequestAsync<TResponse>(string method, 
                                                          List<KeyValuePair<string, string>> RequestHeader,
                                                          object body = null)
        {
            HttpResponseMessage response = new HttpResponseMessage(new HttpStatusCode());
            HttpRequestMessage request = new HttpRequestMessage(method: GetMethod(), requestUri: this.EndPoint) {  };
            
            //Define os headers informados
            

            if (body!=null) {request.Content = (HttpContent)body;}
            if (RequestHeader != null) { RequestHeader.ForEach(hdr => request.Headers.Add(hdr.Key, hdr.Value)); }

            //**** Metodo Resposavel por enviar o Request Assincrono
            response = await client.SendAsync(new HttpRequestMessage(method: HttpMethod.Get, requestUri: this.EndPoint));

            //Serializa o json retornado
            var responseObject = ConvertResponseJSonToObject(response).ToObject<TResponse>();
            return responseObject;

            HttpMethod GetMethod() => method == "GET" ? HttpMethod.Get : HttpMethod.Post;
        }
        private JObject ConvertResponseJSonToObject(HttpResponseMessage response)
        {
            string jsonContent = response.Content.ReadAsStringAsync().Result;
            JObject jsonObject = JObject.Parse(jsonContent);
            return jsonObject;
        }

        public void Dispose() => client.Dispose();
    }
}
