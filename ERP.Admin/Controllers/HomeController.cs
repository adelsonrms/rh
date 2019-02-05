using AutoMapper;
using ERP.Presentation.Api.Models;
using ERP.RH.Application;
using Microsoft.AspNet.Identity;
using RH.Domain.Entities;
using RH.ViewModel;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace RH.UI.Controllers
{
    [Authorize()]
    public class HomeController : Controller
    {
        private readonly FuncionarioApplication _app = new FuncionarioApplication(AppConfig.ConnectionString);

        public ActionResult Index()
        {

            DashboardViewModel dashboard = new DashboardViewModel();

            ViewBag.Funcionario = _app.ObtemFuncionario(User.Identity.GetUserName());

            var listaDeFuncionarios = _app.ObtemListaDeFuncionarios();
            var lista = Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(listaDeFuncionarios);

            dashboard.Funcionarios = lista;

            dashboard.QtdDeFuncionarios = listaDeFuncionarios.Count();

            dashboard.QtdDeFuncionariosAtivos = listaDeFuncionarios.Count(f => f.Ativo == true);

            dashboard.QtdNovasContratacoesNoAno = 0;//listaDeFuncionarios.Count(f => Convert.ToDateTime(f.Contrato.DataAdmissao).Year == DateTime.Now.Year);

            //Devolve o resultado para View
            return View(dashboard);
        }

       

    }
}