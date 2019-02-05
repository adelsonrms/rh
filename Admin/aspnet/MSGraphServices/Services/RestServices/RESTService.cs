using MSGraphService.RestServices.Auth;
using MSGraphService.RestServices.Clients;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MSGraphService.RestServices
{
    public class RESTService<TRestClient>:IDisposable
    {
        public Uri EndPoint { get;private set; }
        private IRestApiClient httpClient;
        private List<KeyValuePair<string, string>> _headers;
        /// <summary>
        /// Inicializa um novo serviço
        /// </summary>
        /// <param name="endPoint"></param>
        public RESTService(string endPoint){
            //Instancia dinamicamente a instancia da classe HttpClient informada pelo tipo generico TRestClient
            //A classe deve conter um construtur
            httpClient = (IRestApiClient)Activator.CreateInstance(typeof(TRestClient), endPoint) ;
        }
        public List<KeyValuePair<string, string>> Headers
        {
            get => _headers?? new List<KeyValuePair<string, string>>();
            set { _headers = value; }
        }
        public List<KeyValuePair<string, string>> AddHeader(string name, string value)
        {

            _headers = this._headers ?? new List<KeyValuePair<string, string>>();
            _headers.Add(new KeyValuePair<string, string>(name, value));
            return Headers;
        }
        public async Task<Response> Post<TObjectToResponse>(object body) where TObjectToResponse : new() => await httpClient.PostAsync<TObjectToResponse>(Headers, body);
        public async Task<Response> Get<TObjectToResponse>() where TObjectToResponse : new() => await httpClient.GetAsync<TObjectToResponse>(Headers);
        public void Dispose() => httpClient.Dispose();
    }

   
}
