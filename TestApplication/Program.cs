using Microsoft.Graph;
using MSGraph.Services;
using MSGraphService.RestServices.Auth;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var _graphClient = new MSGraphApiService(new AppClient());
            var usr = _graphClient.GetUser<Microsoft.Graph.Message>();
            var OfficeUser = usr.Result;
        }
    }
}
