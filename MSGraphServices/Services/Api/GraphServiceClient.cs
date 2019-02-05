using MSGraphService.RestServices;
using MSGraphService.RestServices.Auth;
using MSGraphService.RestServices.Clients;
using MSGraphService.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MSGraph.Services
{
    public class MSGraphApiService
    {
        private readonly string MSGraphServiceEndPoint = "https://graph.microsoft.com/v1.0";
        private AccessToken _accessToken;
        public MSGraphApiService(string userId)
        {
            UserId = userId;
        }
        public MSGraphApiService(AppClient appClient)
        {
             AppClient = appClient;
            _accessToken = new AccessToken();
        }
        public MSGraphApiService(AppClient appClient, string userId)
        {
             UserId = userId;
             AppClient = appClient;
            _accessToken = new AccessToken();
        }
        public MSGraphApiService(AccessToken accessToken){this.AccessToken = accessToken;}
        private AppClient AppClient { get; set; }
        private AccessToken AccessToken
        {
            get
            {
                if (_accessToken == null) _accessToken = new AccessToken();
                return _accessToken;
            }
            set { _accessToken = value; }
        }
        public string ODataQuery { get; set; }
        public string UserId { get; set; }
        public string EndPoint { get; set; }
        public async Task<Response> GetUser<TUser>() where TUser : new()
        {
            TUser result = new TUser();
            Response ResultResponse = new Response();
            
            try
            {
                //Efetua a requisição invocando a função local ExecuteLocalRequest()
                ResultResponse = await ExecuteLocalRequest();

                //Trata o retorno da requisição.
                if (ResultResponse.Status == HttpStatusCode.OK)
                {
                    var data = ResultResponse.Data;
                    result = data;
                }
                else
                {
                    if (ResultResponse.Status == HttpStatusCode.Unauthorized)
                    {
                        //Token invalido, requisita um novo
                        AccessToken = AccessTokenConfig.GetAccessToken(AppClient);
                        //Executa novamente a consulta com o novo Token
                        ResultResponse = await ExecuteLocalRequest();
                    }
                    else
                    {
                        return ResultResponse;
                    }
                }

                //Função local que executa a requisição das infromações do usuário.
                //Essa função só é visivel nesse metodo.
                async Task<Response> ExecuteLocalRequest()
                {
                    this.EndPoint = string.Empty;

                    using (var client = new RESTService<HttpRestClientRestSharp>(getUserEndPoint()))
                    {
                        client.AddHeader("Authorization", "Bearer " + this.AccessToken.access_token);
                        return await client.Get<TUser>();
                    }
                }
            }
            catch
            {

            }

            return ResultResponse;
        }
        public async Task<Response> GetMessages<TMessage>() where TMessage : new()
        {
            List<TMessage> result = new List<TMessage>();

            Response ResultResponse = new Response();

            try
            {
                //Efetua a requisição invocando a função local ExecuteLocalRequest()
                ResultResponse = await ExecuteLocalRequest();

                //Trata o retorno da requisição.
                if (ResultResponse.Status == HttpStatusCode.OK)
                {
                    var data = ResultResponse.Data;

                    var objeto = JSON.StringToObject<TMessage>(ResultResponse.HttpResponse.Content);

                    //result.Add();
                    ResultResponse.Data = result;

                }
                else
                {
                    if (ResultResponse.Status == HttpStatusCode.Unauthorized)
                    {
                        //Token invalido, requisita um novo
                        AccessToken = AccessTokenConfig.GetAccessToken(AppClient);
                        //Executa novamente a consulta com o novo Token
                        ResultResponse = await ExecuteLocalRequest();


                        //var data = ResultResponse.Data;
                        var objeto = JSON.StringToObject<dynamic>(ResultResponse.HttpResponse.Content);
                        ResultResponse.Data = objeto;

                        //result.Add(JSON.StringToObject<TMessage>(ResultResponse.HttpResponse.Content));
                        //ResultResponse.Data = result;


                    }
                    else
                    {
                        return ResultResponse;
                    }
                }

                //Função local que executa a requisição das infromações do usuário.
                //Essa função só é visivel nesse metodo.
                async Task<Response> ExecuteLocalRequest()
                {
                    this.EndPoint = this.EndPoint ?? $"/messages";

                    using (var client = new RESTService<HttpRestClientRestSharp>(getUserEndPoint()))
                    {
                        //Headers necessário para obtenção da foto.Content-Type e Authrization Token
                        //client.AddHeader("Content-Type", "image/jpg");
                        client.AddHeader("Authorization", "Bearer " + this.AccessToken.access_token);
                        return await client.Get<TMessage>();
                    }
                }

            }
            catch
            {

            }

            return ResultResponse;
        }
        public async Task<Response> GetPhoto<TPhoto>(string tamanho) where TPhoto : new()
        {
            //https://graph.microsoft.com/v1.0/me/photos/48x48/$value
            Response ResultResponse = new Response();

            this.AccessToken = AccessTokenConfig.GetAccessToken(AppClient);

            ResultResponse = await ExecuteLocalRequest();

            //var stream = ResultResponse.HttpResponse.Content.ReadAsStreamAsync();

            // var pic = Convert.ToBase64String(ResultResponse.HttpResponse.Content);

            return ResultResponse;

            //Função local que executa a requisição das infromações do usuário.
            //Essa função só é visivel nesse metodo.
            async Task<Response> ExecuteLocalRequest()
            {
                this.EndPoint = this.EndPoint??$"/photos/{tamanho ?? "48x48"}/$value";

                using (var client = new RESTService<HttpRestClientNative>(getUserEndPoint()))
                {
                    //Headers necessário para obtenção da foto.Content-Type e Authrization Token
                    //client.AddHeader("Content-Type", "image/jpg");
                    client.AddHeader("Authorization", "Bearer " + this.AccessToken.access_token);
                    return await client.Get<TPhoto>();
                }
            }
        }
        private string getUserEndPoint()
        {
            AppClient = AppClient??new AppClient();
            return string.Format("{0}/users/{1}{2}{3}",
                MSGraphServiceEndPoint,
                UserId.Replace("@" + AppClient.TenanId, "") + "@" + AppClient.TenanId,
                EndPoint, 
                ODataQuery);
        }
    }
}
//    public class MSGraphApiService1
//    {
//        private MSGraphRequest GraphRequest;
//        public MSGraphApiService1()
//        {
//            this.GraphRequest = new MSGraphRequest();
//        }
//        public MSGraphApiService1(AccessToken accessToken)
//        {
//            this.GraphRequest = new MSGraphRequest(accessToken);
//        }
//        public async Task<TUser> GetUserProfile<TUser>(string email) where TUser : new()
//        {
//            var result = await this.GraphRequest.GetRequestUser<TUser>(email);
//            return result;
//        }
//        public async Task<TUser> GetPhoto<TUser>(string email) where TUser : new()
//        {
//            var result = await this.GraphRequest.GetPhoto<TUser>(email);
//            return result;
//        }


//        //photos/48x48/$value
//    }
//}