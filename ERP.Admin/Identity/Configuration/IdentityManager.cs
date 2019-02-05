using ERP.Presentation.Api.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RH.Infra.Data.DBContexts;
using System;
using System.Dynamic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using System.Linq;

namespace ERP.Presentation.Api.Identity.LoginManager
{
    public class IdentityManager
    {
        private ApplicationUser _user;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IOwinContext _owin;
        private Controller _controller;
        private IdentityResult result;
        private ILoginManager _loginForms;
        private ILoginManager _loginExternal;

        public IdentityManager(Controller controller)
        {
            _controller = controller;
            if (controller.HttpContext!=null)
            {
                _owin = controller.HttpContext.GetOwinContext();
            }
        }

        /// <summary>
        /// Gerenciador de Login
        /// </summary>
        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? _controller.HttpContext?.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _signInManager = value;
        }
        /// <summary>
        /// Gerenciador do Usuario
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get => this._userManager ?? _controller.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }
        /// <summary>
        /// Inicializa uma nova instancia do ApplicationUser
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private ApplicationUser NewApplicationUser(string email, string password, string name="")
        {
            return new ApplicationUser()
            {
                Email= email,
                UserName = email,
                PasswordHash = password,
                Name = name
            };
        }

        /// <summary>
        /// Recupera um usuário no banco de dados por email/login/username
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task<ApplicationUser> GetUserByEmail(string email)
        {
            try
            {
                _user = await UserManager.FindByEmailAsync(email);
            }
            catch
            {
                _user = NewApplicationUser(email, string.Empty, string.Empty);

            }

            return _user;
        }
        /// <summary>
        /// Localiza um login por usuário e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<ApplicationUser> GetUser(string email, string password)
        {
            try
            {
                _user = await UserManager.FindAsync(email, password);
            }
            catch
            {
                _user = NewApplicationUser(email, string.Empty, string.Empty);

            }

            return _user;
        }
        /// <summary>
        /// Cria um novo Usuario no banco de dados do Identity
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<ApplicationUser> CreateUser(ApplicationUser user)
        {

            try
            {
                result = await UserManager.CreateAsync(user, user.PasswordHash);

                if (result.Succeeded)
                {
                    user = await GetUser(user.Email, user.PasswordHash);
                }
            }
            catch
            {
                user = NewApplicationUser(user.Email, string.Empty, string.Empty);
            }

            return user;
        }
        /// <summary>
        /// Cria uma Rola para o usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IdentityRole CreateRole(ApplicationUser user, string name)
        {
            var db = ApplicationDbContext.Create();
            IdentityRole role = null;

            if (db.Roles.Any())
            {
                //Cria uma nova role caso nao exista
                try
                {
                    role = db.Roles.ToList().First(r => r.Name == name);
                }
                catch (Exception)
                {
                    role = db.Roles.Add(new IdentityRole(name));
                    db.SaveChanges();
                }

            }

            try
            {
                //Associa ao usuario
                result = UserManager.AddToRoleAsync(user.Id, name).Result;

                db.SaveChanges();

                //Obtem a instancia da Role Criada.
                role = db.Roles.ToList().First(r => r.Name == name);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return role;
        }
        /// <summary>
        /// O Processo de Registro consiste em :
        ///     - Criar a entrada do usuário no banco de dados.
        ///     -  Cria uma role padrao Usuario
        ///     - Gerar o email de confirmação
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<TaskResult> Register(string email, string password, string name = "", string returnUrl = "")
        {
            TaskResult taskResult = TaskResult.Create();

            try
            {
                //Define um novo usuário
                var userTask = CreateUser(NewApplicationUser(email, password, name));

                _user = userTask.Result;

                //Caso o usuário tenha sido criado com sucesso, efetua o Login
                if (userTask.Result.Exists)
                {
                    //Cria a role padrão
                    CreateRole(_user, "Usuario");

                    TaskResult LoginResult = await LoginForm(_user.Email, _user.PasswordHash);

                    if (LoginResult.Success)
                    {
                        taskResult.Success = true;

                        var redirectTo = LoginResult.Data;

                        taskResult.SetResultInfo(taskResult.Success, "Registro do usuario realizado com sucesso", redirectTo);
                    }
                    else
                    {
                        taskResult.SetResultInfo(false, "Ocorreu um erro ao registrar o usuário", LoginResult);
                    }
                }
            }
            catch (Exception e)
            {
                taskResult.AddError(e);
                taskResult.SetResultInfo(false, "Ocorreu uma Exception no processo de Registro do Usuario (" + e.Message + ")", new RedirectTo(){Controller = "Account", Action = "Error"});
            }
            return taskResult;
        }

        private RedirectTo DefineRedirect(string returnUrl, TaskResult taskResult)
        {
            RedirectTo redirectTo = new RedirectTo();

            returnUrl = returnUrl ?? "/";

            switch ((SignInStatus)taskResult.Data.result)
            {
                case SignInStatus.Success:
                    redirectTo.Url = returnUrl;
                    break;
                case SignInStatus.LockedOut:
                    redirectTo.Controller = "Account";
                    redirectTo.Action = "Lockout";
                    break;
                case SignInStatus.RequiresVerification:
                    redirectTo.Controller = "Account";
                    redirectTo.Action = "SendCode";
                    redirectTo.RouterArgs = new { ReturnUrl = returnUrl, RememberMe = false };
                    break;
                case SignInStatus.Failure:
                    redirectTo.Controller = "Account";
                    redirectTo.Action = "FailureLogin";
                    break;
            }

            return redirectTo;
        }

        public async Task<TaskResult> LoginForm(string username, string password, string returnUrl="")
        {
            TaskResult loginResult = TaskResult.Create();
            RedirectTo redirectTo = new RedirectTo();

            try
            {
                _loginForms = new LoginFormManager(SignInManager);

                loginResult = await _loginForms.Login(NewApplicationUser(username, password));
                loginResult.SetResultInfo(loginResult.Success, loginResult.Message, DefineRedirect(returnUrl, loginResult));
            }
            catch (Exception e)
            {
                redirectTo.Action = "Error";
                redirectTo.Controller = "Account";
                loginResult.AddError(e);
                loginResult.SetResultInfo(false, "Ocorreu uma Exception no processo de Registro do Usuario (" + e.Message + ")", redirectTo);
            }
            return loginResult;
        }

        public async Task<TaskResult> LoginExternal(string username, string password, string returnUrl = "")
        {
            TaskResult loginResult = TaskResult.Create();
            RedirectTo redirectTo = new RedirectTo();

            try
            {
                _loginExternal = new LoginExternalManager(SignInManager);

                loginResult = await _loginForms.Login(NewApplicationUser(username, password));
                loginResult.SetResultInfo(loginResult.Success, loginResult.Message, DefineRedirect(returnUrl, loginResult));
            }
            catch (Exception e)
            {
                redirectTo.Action = "Error";
                redirectTo.Controller = "Account";
                loginResult.AddError(e);
                loginResult.SetResultInfo(false, "Ocorreu uma Exception no processo de Registro do Usuario (" + e.Message + ")", redirectTo);
            }
            return loginResult;
        }
        /// <summary>
        /// Gera o email de confirmação do cadastro. Retorna a URL com o codigo de ativação
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<string> GerarEmailDeConfirmacao(ApplicationUser user)
        {
            try
            {
                //Gera o codigo criptografado que será usado para validar o email
                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                //Gera a URL de callback que será enviado ao email do usuário para confirmação
                var callbackUrl = "";//Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                //ModelState.AddModelError("", error);
            }
        }

    }
}