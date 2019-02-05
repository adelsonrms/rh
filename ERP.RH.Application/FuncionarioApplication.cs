using RH.Domain.Entities;
using RH.Domain.Repositories;
using RH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using RH.ViewModel;

namespace ERP.RH.Application
{
    public class FuncionarioApplication: EntityDapperApplication<Funcionario>
    {

        Funcionario _funcionario = null;
        public FuncionarioApplication()
        {

        }
        public FuncionarioApplication(string connectionString) : base(connectionString) { }

        public IEnumerable<Funcionario> ObtemListaDeFuncionarios() => Rep.ObterTodos();

        public void SalvaFuncionario(Funcionario model)
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

        public Funcionario ObtemFuncionario(Funcionario funcionario)
        {
            try
            {
                this._funcionario = funcionario;
                PopulaInformacoesFuncionario();
            }
            catch (Exception e)
            {
                this._funcionario = funcionario;
                Console.WriteLine(e);
            }
            return this._funcionario;
        }
        /// <summary>
        /// Recupera um funcionario 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Funcionario ObtemFuncionario(int id)
        {
            try
            {
                //Busca o funcionario na base
                this._funcionario = Rep.ObterPorId(id);

                PopulaInformacoesFuncionario();

            }
            catch (Exception e)
            {
                this._funcionario = new Funcionario();
                Console.WriteLine(e);
            }
            return this._funcionario;
        }

        public string CalculaIdade(Funcionario funcionario)
        {
            string idade="";

            if (funcionario.DataNascimento != null)
            {
                idade = new DateService().TempoDecorrido(funcionario.DataNascimento, DateTime.Today, "y");
            }
            return idade;
        }

        public Funcionario ObtemFuncionario(string email)
        {
            try
            {
                var lista = Rep.ObterTodos();
                //Busca o funcionario na base
                this._funcionario = lista.Where(f => f.EmailProfissional == email).SingleOrDefault();

                PopulaInformacoesFuncionario();
            }
            catch 
            {
                this._funcionario = new Funcionario();
            }
            return this._funcionario;
        }

        private void PopulaInformacoesFuncionario()
        {
            if (this._funcionario !=null)
            {

                //Busca informações dos contratos de trabalho
                var contrato = new ContratoApplication().RecuperaContratoPorFuncionario(this._funcionario);

                //Recupera o primeiro contrato ativo mais recente
                this._funcionario.Contrato = contrato;

                //Obtem informações sobre os documentos
                this._funcionario.Documento = new EntityApplication<Documento>().ObterTodos().SingleOrDefault(f => f.IdFuncionario == this._funcionario.Id);

                //Calcula a idade do funcionario baseado na sua data de nascimento
                this._funcionario.Idade = CalculaIdade(this._funcionario);
            }
        }
    }

}
