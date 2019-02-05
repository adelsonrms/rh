using ERP.Shared.Web;
using Microsoft.AspNet.Identity;
using MSGraph.Services;
using MSGraphService.Models;
using MSGraphService.RestServices.Auth;
using MSGraphService.RestServices.Clients;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.Presentation.Api.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpPost]
        [Authorize]
        public async Task<JsonResult> GetUserInfo()
        {
            var MSGraph = new MSGraphApiService(new AppClient());

            //Recupera informações sobre o perfil do usuario atraves do email
            Response responseQuery = await MSGraph.GetUser<User>(HttpContext.User.Identity.GetUserName());
            var user = responseQuery.Data;

            if (user.IsValid())
            {
                return Json(user);
            }
            else
            {
                return Json(new User(){GivenName = "Erro", Response = responseQuery.HttpResponse });
            }
            
        }

        public async Task<JsonResult> GetPhoto()
        {
            string photoBase64 = Imagens.UserDesconhecido;

            try
            {
                photoBase64 = await GetUserPhoto(HttpContext.User.Identity.GetUserName());
            }
            catch 
            {

            }
            return Json(new { imageBase64 = photoBase64 });
        }

        public async Task<string> GetUserPhoto(string userId)
        {
            var MSGraph = new MSGraphApiService(new AppClient());
            string mediaType="";
            string thumbnail="";

            //Recupera informações sobre o perfil do usuario atraves do email
            Response responseQuery = await MSGraph.GetPhoto<ProfilePhoto>(userId);

            var response = responseQuery.HttpResponse;

            if (response.IsSuccessStatusCode)
            {
                // Read the response as a byte array
                var responseBody = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

                // The headers will contain information on the image type returned
                mediaType = response.Content.Headers.ContentType.MediaType;

                // Encode the image string
                thumbnail = Convert.ToBase64String(responseBody);
            }

            return $"data:{mediaType};base64,{thumbnail}";
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut("Cookies");
            return RedirectToAction("Index", "Home");
        }

    }
}