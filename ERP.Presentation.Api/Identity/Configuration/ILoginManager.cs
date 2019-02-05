using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using RH.Infra.Data.DBContexts;
using System.Threading.Tasks;

namespace ERP.Presentation.Api.Identity.LoginManager
{
    public interface ILoginManager
    {
        Task<TaskResult> Login(ApplicationUser user);
        bool Logout();
    }
}
