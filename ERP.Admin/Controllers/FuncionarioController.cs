using AutoMapper;
using ERP.Presentation.Api.Models;
using ERP.Presentation.Api.Properties;
using ERP.RH.Application;
using RH.Domain.Entities;
using RH.Services;
using RH.UI;
using RH.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ERP.Presentation.Api.Controllers
{
    [Authorize()]
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioApplication _app = new FuncionarioApplication();
//
        // GET: /Funcionario/
        
        /// <summary>
        /// Retorna a lista de funcionarios
        /// </summary>
        /// <returns></returns>
        public ActionResult ListaDeFuncionarios()
        {
            //Recupera a lista de funcionarios
            using (this._app)
            {
                var funcionarios = _app.ObtemListaDeFuncionarios();

                var lista = Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(funcionarios);
                //var lista = funcionarios;

                //Devolve o resultado para View
                return View(lista);
            }
        }

        public ActionResult ListaDeFuncionariosCard()
        {
            //Recupera a lista de funcionarios
            using (this._app)
            {
                var funcionarios = _app.ObtemListaDeFuncionarios();

                var lista = Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(funcionarios);
                //var lista = funcionarios;

                //Devolve o resultado para View
                return View("ListCard", lista);
            }
        }

        //ListCard

        /// <summary>
        /// Acessa a pagina de detalhes do funcionario selecionado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modo"></param>
        /// <returns></returns>
        public ActionResult FichaCadastral(int id, string modo)
        {
            //ViewBag.ComboPerfil = 
            //PopulaCombos();
            bool editar = (modo == "edit");

            using (EntityApplication<Cargo> app = new EntityApplication<Cargo>())
            {
                ViewData["cmbCargos"] = new DropDownService().GerarComboSelect(fonte:app.ObterTodos(),campoValor: "Id", campoTexto: "Nome");
            }

            using (EntityApplication<Modalidade> app = new EntityApplication<Modalidade>())
            {
                ViewData["cmbModalidade"] = new DropDownService().GerarComboSelect(app.ObterTodos(), "Id", "NomeModalidade");
            }

            using (EntityApplication<EstadoCivil> app = new EntityApplication<EstadoCivil>())
            {
                ViewData["cmbEstadoCivil"] = new DropDownService().GerarComboSelect(app.ObterTodos(), "Id", "Nome");
            }

            ViewBag.TituloDaPagina = "Ficha Cadastral";
            ViewBag.Editar = editar;
            ViewBag.Modo = modo;

            FuncionarioViewModel funcionario;

            if (modo=="edit" || modo=="read")
            {
                funcionario = Mapper.Map<Funcionario, FuncionarioViewModel>(_app.ObtemFuncionario(id));  
            }
            else
            {
                funcionario = new FuncionarioViewModel();
            }

            using (ContratoApplication cApp = new ContratoApplication())
            {
                funcionario.Contrato = cApp.RecuperaContratoPorFuncionario(funcionario.Id);
            }


            return View(funcionario);
        }
        
        /// <summary>
        /// Salva informações do funcionatio
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SalvarFuncionario(FuncionarioViewModel model)
        {
            Funcionario funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(model);
            
            _app.SalvaFuncionario(funcionario);
            MensagemParaUsuario.MensagemSucesso("Dados atualizados com sucesso.", TempData);
            var parametros = new {id= model.Id, modo = "read"};
            return RedirectToAction("FichaCadastral", parametros);

        }
    }
}
