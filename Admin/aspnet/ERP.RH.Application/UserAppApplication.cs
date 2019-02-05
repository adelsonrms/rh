using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.RH.Application
{
    public class UserAppApplication : EntityApplication<UserApp>
    {

        UserApp _UserApp = null;

        public IEnumerable<UserApp> ObtemListaDeLogins()
        {
            return Rep.ObterTodos();
        }

        public void SalvaLogin(UserApp model)
        {
            try
            {
                Rep.Alterar(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            ;
        }
        /// <summary>
        /// Recupera um Login 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserApp ObtemLogin(string email)
        {
            try
            {
                //Busca o Login na base
                _UserApp = Rep.ObterTodos().Where(f => f.UserId == email).SingleOrDefault();
            }
            catch (Exception e)
            {
                _UserApp = new UserApp();
            }
            return _UserApp;
        }

        public bool UsuarioHabilitado(string email, string appName)
        {

            try
            {
                _UserApp = Rep.ObterTodos().Where(f => f.UserId == email && f.AppId == appName).SingleOrDefault();
                return (_UserApp != null);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }
    }

}
