using ERP.Shared.Web;
using Microsoft.AspNet.Identity;
using MSGraph.Services;
using MSGraphService.RestServices.Auth;
using MSGraphService.RestServices.Clients;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Message = MSGraphService.Models.Message;
using ProfilePhoto = MSGraphService.Models.ProfilePhoto;
using User = MSGraphService.Models.User;

namespace ERP.Presentation.Api.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        MSGraphApiService _graphService;
        public AuthController()
        {
            _graphService = new MSGraphApiService(new AppClient());
        }
        [HttpPost]
        public async Task<JsonResult> GetUserInfo()
        {
            _graphService.UserId = HttpContext.User.Identity.GetUserName();

            //Recupera informações sobre o perfil do usuario atraves do email
            Response responseQuery = await _graphService.GetUser<User>();
            var user = responseQuery.Data;

            if (user.IsValid())
            {
                return Json(user);
            }
            else
            {
                return Json(new User(){GivenName = "Erro ao consultar o usuario"});
            }
            
        }
        public async Task<JsonResult> GetUserMessages() => await GetMessagesByUser(HttpContext.User.Identity.GetUserName());
        public async Task<JsonResult> GetMessagesByUser(string userId)
        {
            this._graphService.UserId = userId;

            try
            {
                //Recupera informações sobre o perfil do usuario atraves do email
                //Nessa consulta, somente as 5 primeiras mensagens ordenadas por chegada serão recuperadas.

                //Parametro de filtro OData
                _graphService.EndPoint = "/mailFolders/inbox/messages";
                _graphService.ODataQuery = "?&$top=5&$orderby=receivedDateTime desc&$filter=isRead eq false";
                /*
                 *  top=5                               : Somente os ultimos 5 emails
                 *  orderby=receivedDateTime desc       : Ordena o resultado pela data de recebimento Decrescente
                 *  filter=isRead eq false              : Filtra somente os itens não lidos
                 *  O end-point abaixo recupera somente as mensagens da caixa de entrada
                 *  https://graph.microsoft.com/v1.0/me/mailFolders/inbox/messages?$filter=isRead eq false
                 */

                Response responseQuery = await _graphService.GetMessages<Message>();
                var messages = responseQuery.Data;

                //Obtem a leitura dos objetos Message
                var conteudo = ((JContainer)messages).Last;

                var items = conteudo.Children();

                List<Message> list = new List<Message>();

                foreach (var item in items)
                {
                    //Serializa o JSon retornado para o objeto
                    item.Children().ToList().ForEach(m => list.Add(m.ToObject<Message>()));
                }

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new {Error = "Erro ao consultar as mensagens do usuario"}, JsonRequestBehavior.AllowGet);
            }

        }
        public async Task<JsonResult> GetPhoto(string tamanho)
        {
            string photoBase64 = Imagens.UserDesconhecido;

            try
            {
                photoBase64 = await GetUserPhoto(HttpContext.User.Identity.GetUserName(), tamanho);
            }
            catch 
            {

            }
            return Json(new { imageBase64 = photoBase64 });
        }
        public async Task<string> GetUserPhoto(string userId, string tamanho)
        {
            this._graphService.UserId = HttpContext.User.Identity.GetUserName();

            string mediaType="";
            string thumbnail="";

            //Recupera informações sobre o perfil do usuario atraves do email
            Response responseQuery = await _graphService.GetPhoto<ProfilePhoto>( tamanho);

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

    }
}