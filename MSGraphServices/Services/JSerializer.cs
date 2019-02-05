using System;
using Newtonsoft.Json.Linq;

namespace MSGraphService.Services
{
    public static class JSON
    {
        public static TResponse StringToObject<TResponse>(string content) where TResponse : new()
        {
            try
            {
                return JObject.Parse(json: content).ToObject<TResponse>();
            }
            catch
            {
                return default(TResponse);
            }
        }
    }
}
