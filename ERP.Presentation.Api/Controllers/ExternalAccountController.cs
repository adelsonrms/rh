using ERP.Presentation.Api.App_Start;
using ERP.Presentation.Api.Authentication;
using ERP.Presentation.Api.Identity.LoginManager;
using ERP.Presentation.Api.Models;
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
    
    //public class ExternalAccountController : Controller
    //{
    //    private ApplicationSignInManager _signInManager;
    //    private ApplicationUserManager _userManager;
    //    private IdentityManager _identityManager;

    //    public ExternalAccountController()
    //    {
    //    }
    //    public ExternalAccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
    //    {
    //        UserManager = userManager;
    //        SignInManager = signInManager;
    //        _identityManager = new IdentityManager(this);

    //    }
    //    public ApplicationSignInManager SignInManager
    //    {
    //        get
    //        {
    //            return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
    //        }
    //        private set
    //        {
    //            _signInManager = value;
    //        }
    //    }
    //    public ApplicationUserManager UserManager
    //    {
    //        get
    //        {
    //            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        }
    //        private set
    //        {
    //            _userManager = value;
    //        }
    //    }
    //    private IAuthenticationManager AuthenticationManager
    //    {
    //        get
    //        {
    //            return HttpContext.GetOwinContext().Authentication;
    //        }
    //    }
    //    private ActionResult RedirectToLocal(string returnUrl)
    //    {
    //        if (Url.IsLocalUrl(returnUrl))
    //        {
    //            return Redirect(returnUrl);
    //        }
    //        return RedirectToAction("Index", "Home");
    //    }

    //    [HttpPost]
    //    [AllowAnonymous]
    //    public ActionResult ExternalLogin(string provider, string returnUrl)
    //    {
    //        if (string.IsNullOrWhiteSpace(returnUrl) || (returnUrl.ToLower().Contains("account/externallogin")))
    //            returnUrl = "/Home/Index/";

    //        // Solicitar um redirecionamento para o provedor de logon externo
    //        return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
    //    }
    //    // action de callback de login externo, para onde o serviço de login externo deve redirecionar
    //    [AllowAnonymous]
    //    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    //    {
    //        bool autenticado = User.Identity.IsAuthenticated;

    //        var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();

    //        if (loginInfo == null)
    //        {
    //            return RedirectToAction("Login");
    //        }

    //        string email = "";
    //        {
    //            var identity = await AuthenticationManager.AuthenticateAsync(DefaultAuthenticationTypes.ExternalCookie);

    //            var emailClaim = identity.Identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn");
    //            if ((emailClaim != null) && (!string.IsNullOrWhiteSpace(emailClaim.Value)))
    //            {
    //                loginInfo.Email = emailClaim.Value;
    //                email = emailClaim.Value;
    //                System.Diagnostics.Trace.Assert(email == loginInfo.DefaultUserName, "O e-mail não é igual ao UserName");
    //                System.Diagnostics.Debug.Assert(email == loginInfo.DefaultUserName, "O e-mail não é igual ao UserName");
    //            }


    //        }

    //        // Faça logon do usuário com este provedor de logon externo se o usuário já tiver um logon
    //        var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: true);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(returnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.Failure:
    //            default:
    //                // Se o usuário não tiver uma conta, solicite que o usuário crie uma conta
    //                ViewBag.ReturnUrl = returnUrl;
    //                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
    //                return await ExternalLoginConfirmation(new ExternalLoginConfirmationViewModel { Email = email }, returnUrl);
    //        }
    //    }

    //    // confirmação do login externo
    //    // grava os dados do login externo no perfil do usuário, se for de um domínio / serviço que pode entrar
    //    [HttpPost]
    //    [AllowAnonymous]
    //    public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
    //    {
    //        if (User.Identity.IsAuthenticated)
    //        {
    //            return RedirectToAction("Index", "Manage");
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            // Obter as informações sobre o usuário do provedor de logon externo
    //            var info = await AuthenticationManager.GetExternalLoginInfoAsync();
    //            if (info == null)
    //            {
    //                return View("ExternalLoginFailure");
    //            }

    //            if ((string.IsNullOrWhiteSpace(model.Email)) || (model.Email.Split('@').Length < 2) || (model.Email.Split('@')[1].ToLower() != "tecnun.com.br"))
    //            {
    //                TempData["Detalhes"] = "O login deve ser um e-mail @tecnun.com.br válido!";
    //                return View("ExternalLoginFailure");
    //            }

    //            //procura pelo usuário
    //            ApplicationUser user = await UserManager.FindByEmailAsync(model.Email);
    //            if (user == null)
    //            {
    //                //caso não exista, primeiro criamos e...
    //                user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //                var result = await UserManager.CreateAsync(user);
    //                if (result.Succeeded)
    //                {
    //                    //depois adicionamos informação de login externo
    //                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
    //                    if (result.Succeeded)
    //                    {
    //                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                        return RedirectToLocal(returnUrl);
    //                    }
    //                }
    //                AddErrors(result);
    //            }
    //            else
    //            {
    //                //caso já exista apenas adicionamos informação de login externo, acumulando
    //                var result = await UserManager.AddLoginAsync(user.Id, info.Login);
    //                if (result.Succeeded)
    //                {
    //                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                    return RedirectToLocal(returnUrl);
    //                }
    //                AddErrors(result);
    //            }
    //        }

    //        ViewBag.ReturnUrl = returnUrl;
    //        return View("ExternalLoginConfirmation", model);
    //    }
    //    // ação de logoff de serviço externo
    //    [AllowAnonymous]
    //    public void SignOuExterno()
    //    {
    //        string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);

    //        HttpContext.GetOwinContext().Authentication.SignOut(
    //            new AuthenticationProperties
    //            {
    //                RedirectUri = callbackUrl
    //            },
    //            OpenIdConnectAuthenticationDefaults.AuthenticationType, 
    //            CookieAuthenticationDefaults.AuthenticationType);
    //    }
    //    // callback do logoff
    //    /// <returns></returns>
    //    [AllowAnonymous]
    //    public ActionResult SignOutCallback()
    //    {
    //        if (!Request.IsAuthenticated)
    //        {
    //            // Redirect to home page if the user is authenticated.
    //            return RedirectToAction("Login", "Account");
    //        }

    //        return View();
    //    }
    //    private void AddErrors(IdentityResult result)
    //    {
    //        foreach (var error in result.Errors)
    //        {
    //            ModelState.AddModelError("", error);
    //        }
    //    }

    //}
}
