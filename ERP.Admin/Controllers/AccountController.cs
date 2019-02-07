using ERP.Presentation.Api.App_Start;
using ERP.Presentation.Api.Authentication;
using ERP.Presentation.Api.Identity.LoginManager;
using ERP.Presentation.Api.Models;
using ERP.RH.Application;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using RH.Infra.Data.DBContexts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RH.UI.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IdentityManager _identityManager;

        public AccountController()
        {
            _identityManager = new IdentityManager(this);
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _identityManager = new IdentityManager(this);
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [AllowAnonymous]
        public ActionResult Logout(string returnUrl)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult LoginTecnun()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Ajusta o dominio do login
            model.Email = model.Email.Replace("@tecnun.com.br", "") + "@tecnun.com.br";

        var result = await _identityManager.LoginForm(model.Email, model.Password, returnUrl);

            if (result.Success)
            {
                //Verifica se o login está habilitado
                UserAppApplication _UseApp = new UserAppApplication();

                if (!_UseApp.UsuarioHabilitado(model.Email, "TECUNU.ERP.RH.WebApp"))
                {

                    return RedirectToAction("ErrorLogin", "Account", new { mensagem = "Usuário não habilitado para usar o sistema" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
        }


        private ActionResult RedirectTo(RedirectTo redirect)
        {
            if (Url.IsLocalUrl(redirect.Url))
            {
                return Redirect(redirect.Url);
            }
            return RedirectToAction(redirect.Action, redirect.Controller);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }
        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registrar(RegistrarContaViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    //Define um novo usuário
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    
                    //Cria a entrada do usuário no banco de dados
                    var result = await UserManager.CreateAsync(user, model.Senha);

                    //Caso o usuário tenha sido criado com sucesso, efetua o Login
                    if (result.Succeeded)
                    {
                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                       // CriarUserRole(user, "User");

                        var callbackUrl = await GerarEmailDeConfirmacao(user);

                        ViewBag.Link = callbackUrl;

                        return View("DisplayEmail");
                        //return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
                // If we got this far, something failed, redisplay form
                return View(model);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void CriarUserRole(ApplicationUser user, string roleName)
        {
            var db = ApplicationDbContext.Create();
            IdentityRole role;

            if (db.Roles.Any())
            {
                try
                {
                    role = db.Roles.ToList().First(r => r.Name == roleName);
                }
                catch (Exception)
                {
                    role = db.Roles.Add(new IdentityRole(roleName));
                    db.SaveChanges();
                }

            }

            UserManager.AddToRoleAsync(user.Id, roleName);
            db.SaveChanges();
        }

        private void CriarUserRole(string usuario, string senha, string roleName)
        {
            var user = UserManager.Find(usuario, senha);
            CriarUserRole(user, roleName);

        }

        private async Task<string> GerarEmailDeConfirmacao(ApplicationUser user)
        {
            try
            {
                //Gera o codigo criptografado que será usado para validar o email
                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                //Gera a URL de callback que será enviado ao email do usuário para confirmação
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                //Invoca o envio do email para a classe de serviço pre-configurada
                await UserManager.SendEmailAsync(user.Id,
                    "Confirme sua Conta",
                    "Clique no link a seguir para confirmar o cadastro :\n <br /><br /><a class='btn btn-default' href='" + callbackUrl + "'>Confirmar</a>"
                );

                //Retorna a url que foi enviada.
                return callbackUrl;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #region Metodos de Login Externo usando Office 365

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginOffice365(string provider, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl) || (returnUrl.ToLower().Contains("account/externallogin")))
                returnUrl = "/Home/Index/";

            // Solicitar um redirecionamento para o provedor de logon externo
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }
        
        // action de callback de login externo, para onde o serviço de login externo deve redirecionar
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            bool autenticado = User.Identity.IsAuthenticated;

            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            string email = "";
            {
                var identity = await AuthenticationManager.AuthenticateAsync(DefaultAuthenticationTypes.ExternalCookie);

                var emailClaim = identity.Identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn");
                if ((emailClaim != null) && (!string.IsNullOrWhiteSpace(emailClaim.Value)))
                {
                    loginInfo.Email = emailClaim.Value;
                    email = emailClaim.Value;
                    System.Diagnostics.Trace.Assert(email == loginInfo.DefaultUserName, "O e-mail não é igual ao UserName");
                    System.Diagnostics.Debug.Assert(email == loginInfo.DefaultUserName, "O e-mail não é igual ao UserName");
                }


            }

            // Faça logon do usuário com este provedor de logon externo se o usuário já tiver um logon
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    // Se o usuário não tiver uma conta, solicite que o usuário crie uma conta
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return await ExternalLoginConfirmation(new ExternalLoginConfirmationViewModel { Email = email }, returnUrl);
            }
        }
        // confirmação do login externo
        // grava os dados do login externo no perfil do usuário, se for de um domínio / serviço que pode entrar
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Obter as informações sobre o usuário do provedor de logon externo
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                if ((string.IsNullOrWhiteSpace(model.Email)) || (model.Email.Split('@').Length < 2) || (model.Email.Split('@')[1].ToLower() != "tecnun.com.br"))
                {
                    TempData["Detalhes"] = "O login deve ser um e-mail @tecnun.com.br válido!";
                    return View("ExternalLoginFailure");
                }

                //procura pelo usuário
                ApplicationUser user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    //caso não exista, primeiro criamos e...
                    user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        //depois adicionamos informação de login externo
                        result = await UserManager.AddLoginAsync(user.Id, info.Login);
                        if (result.Succeeded)
                        {
                            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                            return RedirectToLocal(returnUrl);
                        }
                    }
                    AddErrors(result);
                }
                else
                {
                    //caso já exista apenas adicionamos informação de login externo, acumulando
                    var result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                    AddErrors(result);
                }
            }

            ViewBag.ReturnUrl = returnUrl;
            return View("ExternalLoginConfirmation", model);
        }
        
        // ação de logoff de serviço externo
        [AllowAnonymous]
        public void SignOuExterno()
        {
            string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);

            HttpContext.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties
                {
                    RedirectUri = callbackUrl
                },
                OpenIdConnectAuthenticationDefaults.AuthenticationType, 
                CookieAuthenticationDefaults.AuthenticationType);
        }

        #endregion

        // callback do logoff
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult SignOutCallback()
        {
            if (!Request.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult ErrorLogin(string mensagem)
        {
            return View("ErrorLogin", new ErrorViewModel(){Mensagem = mensagem});
        }

    }
}
