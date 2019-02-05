using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MSGraphService.RestServices.Clients
{
    public interface IRestApiClient: IDisposable
    {
        string EndPoint { get; set; }
        Task<Response> GetAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader) where TResponse : new();
        Task<Response> PostAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader, object body) where TResponse : new();
    }
}