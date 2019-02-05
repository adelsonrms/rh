using System;
using ERP.Presentation.Api.App_Start;
using Microsoft.AspNet.Identity.Owin;
using RH.Infra.Data.DBContexts;
using System.Threading.Tasks;

namespace ERP.Presentation.Api.Identity.LoginManager
{
    public class LoginFormManager : ILoginManager
    {
        private ApplicationSignInManager _signInManager;

        public LoginFormManager(ApplicationSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Gerenciador de Login
        /// </summary>
        public ApplicationSignInManager SignInManager
        {
            get => _signInManager;
            private set => _signInManager = value;
        }
        /// <summary>
        /// Efetua o login do usuario com o provedor local
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<TaskResult> Login(ApplicationUser user)
        {
            TaskResult taskResult = new TaskResult();
            try
            {
                var result = await SignInManager.PasswordSignInAsync(user.Email, user.PasswordHash, true, shouldLockout: false);

                if (result == SignInStatus.Success)
                {
                    taskResult.SetResultInfo(true, "Usuario efetuou login com sucesso !", new { result, user });
                }
                else
                {
                    taskResult.AddError(new Exception("Usuário inexistente ou senha inválida"));
                    taskResult.SetResultInfo(false, "Usuário inexistente ou senha inválida", new { result });
                }
            }
            catch (Exception e)
            {
                taskResult.AddError(e);
                taskResult.SetResultInfo(false, "Ocorreu uma Exception inesperada no processo de logon (" + e.Message  +")", new { Exception = e });
            }
            return taskResult;
        }
        public bool Logout() => throw new System.NotImplementedException();
        
    }

    public class LoginExternalManager : ILoginManager
    {
        private ApplicationSignInManager _signInManager;

        public LoginExternalManager(ApplicationSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Gerenciador de Login
        /// </summary>
        public ApplicationSignInManager SignInManager
        {
            get => _signInManager;
            private set => _signInManager = value;
        }
        /// <summary>
        /// Efetua o login do usuario com o provedor local
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<TaskResult> Login(ApplicationUser user)
        {
            TaskResult taskResult = new TaskResult();
            try
            {
                var result = await SignInManager.PasswordSignInAsync(user.Email, user.PasswordHash, true, shouldLockout: false);

                if (result == SignInStatus.Success)
                {
                    taskResult.SetResultInfo(true, "Usuario efetuou login com sucesso !", new { result, user });
                }
                else
                {
                    taskResult.AddError(new Exception("Falha na tentativa de logon \n Usuário ou senha inválido"));
                    taskResult.SetResultInfo(false, "Falha na tentativa de logon. Usuário ou senha inválido", new { result });
                }
            }
            catch (Exception e)
            {
                taskResult.AddError(e);
                taskResult.SetResultInfo(false, "Ocorreu uma Exception no processo de logon (" + e.Message + ")", new { Exception = e });
            }
            return taskResult;
        }
        public bool Logout() => throw new System.NotImplementedException();

    }

}