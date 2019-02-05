using ERP.Presentation.Api.Models;
using RH.Infra.Data;
using System.Web.Mvc;

namespace ERP.Presentation.Api.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Auth

        [HttpGet]
        public ActionResult RunSQL()
        {
            return View(new SQLViewModel() { Command="...TSQL...", Conexao = System.Configuration.ConfigurationManager.AppSettings["TPAContextConnStr"] });
        }

        [HttpPost]
        public ActionResult RunSQL(SQLViewModel mv)
        {
            DBConnection db = new DBConnection();

            if (ModelState.IsValid)
            {
                DBContext.ExecuteScalar(mv.Command, db);
            }
            return View(new SQLViewModel() { Command= mv.Command });
        }


    }
}