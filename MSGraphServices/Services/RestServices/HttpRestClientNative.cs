using MSGraphService.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MSGraphService.RestServices.Clients
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
        public async Task<Response> GetAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader) where TResponse : new() => await ExecuteRequestAsync<Response>("GET", RequestHeader);
        public async Task<Response> PostAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader, object body) where TResponse : new() => await ExecuteRequestAsync<Response>("POST", RequestHeader, body);
        /// <summary>
        /// Envia o Request para o servidor informando o tipo
        /// </summary>
        /// <typeparam name="TResponse">Objeto de retorno a ser deserializado do json</typeparam>
        /// <param name="method">Metodo do Request</param>
        /// <param name="RequestHeader">Cabeçalhos do Request</param>
        /// <param name="body">Conteudo do corpo do request. No caso do POST</param>
        /// <returns></returns>
        private async Task<Response> ExecuteRequestAsync<TResponse>(string method, List<KeyValuePair<string, string>> RequestHeader,object body = null) where TResponse : new()
        {
            HttpResponseMessage response = new HttpResponseMessage(new HttpStatusCode());

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(method: GetMethod(), requestUri: this.EndPoint) { };

                //Define os headers informados
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));
            



                if (body!=null) {request.Content = (HttpContent)body;}

            //foreach (var hdr in RequestHeader)
            //{
            //    request.Headers.TryAddWithoutValidation(hdr.Key, hdr.Value);
            //}

            if (RequestHeader != null) { RequestHeader.ForEach(hdr => request.Headers.Add(hdr.Key, hdr.Value)); }

            //**** Metodo Resposavel por enviar o Request Assincrono
            response = await client.SendAsync(request);

            //Serializa o json retornado
            var ResponseObject = JSON.StringToObject<TResponse>(response.Content.ReadAsStringAsync().Result);

            return await Task.FromResult(
                new Response()
                {
                    Status = response.StatusCode,
                    Description = response.ReasonPhrase,
                    Data = ResponseObject,
                    HttpResponse = response
                });



                HttpMethod GetMethod() => method == "GET" ? HttpMethod.Get : HttpMethod.Post;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public void Dispose() => client.Dispose();
    }
}
