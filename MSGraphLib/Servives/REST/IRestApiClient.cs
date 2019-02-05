using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ERP.Shared.RestServices
{
    public interface IRestApiClient: IDisposable
    {
        string EndPoint { get; set; }
        Task<TResponse> GetAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader) where TResponse : new();
        Task<TResponse> PostAsync<TResponse>(List<KeyValuePair<string, string>> RequestHeader, object body) where TResponse : new();
    }
}