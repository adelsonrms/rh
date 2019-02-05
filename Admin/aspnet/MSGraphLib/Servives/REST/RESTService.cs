using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Shared.RestServices
{
    public class RESTService<TRestClient>:IDisposable
    {
        public Uri EndPoint { get;private set; }
        private IRestApiClient httpClient;
        /// <summary>
        /// Inicializa um novo serviço
        /// </summary>
        /// <param name="endPoint"></param>
        public RESTService(string endPoint){
            //Instancia dinamicamente a instancia da classe HttpClient informada pelo tipo generico TRestClient
            //A classe deve conter um construtur
            httpClient = (IRestApiClient)Activator.CreateInstance(typeof(TRestClient), endPoint) ;
        }
        public async Task<TResponse> Post<TResponse>(List<KeyValuePair<string, string>> RequestHeader, object body) where TResponse : new() => await httpClient.PostAsync<TResponse>(RequestHeader, body);
        public async Task<TResponse> Get<TResponse>(List<KeyValuePair<string, string>> RequestHeader) where TResponse : new() => await httpClient.GetAsync<TResponse>(RequestHeader);
        public void Dispose() => httpClient.Dispose();
    }
}
