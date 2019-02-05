//using MSGraph.Services;
//using MSGraphService.Models;
//using MSGraphService.RestServices.Auth;

//namespace ApiIdentityServices
//{
//    public class MSGraphUserService
//    {
//        readonly string _email;
//        MSGraphApiService _graphClient;
//        public User OfficeUser { get; set; }

//        public MSGraphUserService()
//        {
//            _graphClient = new MSGraphApiService(new AppClient());
//        }

//        public MSGraphUserService(string email)
//        {
//            _email = email;
//            _graphClient = new MSGraphApiService(AccessTokenConfig.AccessToken);
//            GetUserAsync();
//        }

//        private void GetUserAsync()
//        {
//            try
//            {
//                var usr = _graphClient.GetUser<User>(_email);
//                OfficeUser = usr.Result.Data;
//            }
//            catch (System.Exception)
//            {
//                System.Diagnostics.Debugger.Break();
//                throw;
//            }
//        }
//    }
//}