using RH.Domain.Entities;
using RH.ViewModel;
using System.Collections.Generic;

namespace ERP.Presentation.Api.Models
{
    public class DashboardViewModel
    {
        public int QtdDeFuncionarios { get; set; }
        public int QtdDeClientes { get; set; }
        public int QtdDeFuncionariosAtivos { get; set; }
        public int QtdNovasContratacoesNoAno { get; set; }

        public IEnumerable<FuncionarioViewModel> Funcionarios { get; set; }
    }
}