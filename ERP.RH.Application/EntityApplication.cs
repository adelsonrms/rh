using RH.Domain.Repositories;
using RH.Infra.Data.DBContexts;
using System;
using System.Collections.Generic;

namespace ERP.RH.Application
{
    public class EntityApplication<T>: DataContext, IEntityApplication<T> where T:class 
    {
        protected IGenericRepository<T> Rep { get; }

        public EntityApplication()
        {
            Rep = InicializaRepositorio<T>();
        }
        public IEnumerable<T> ObterTodos()
        {
            IEnumerable<T> lista;
            try
            {
                lista = Rep.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter os dados da lista do Repositorio", ex);
            }
            return lista;
        }
        public void Salvar(T entidade)
        {
            try
            {
                Rep.Inserir(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar a Entidade no Banco de dados", ex);
            }


        }
        protected T ObterPorId(int id)
        {
            try
            {
                return Rep.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar a Entidade no Banco de dados", ex);
            }
        }
    }

    public class EntityDapperApplication<T> : DataDapperContext, IEntityApplication<T> where T : class
    {
        protected DapperRepository<T> Rep { get; }
        public EntityDapperApplication()
        {
            Rep = InicializaRepositorio<T>();
        }
        public EntityDapperApplication(string connectionString): base(connectionString)
        {
            Rep = InicializaRepositorio<T>();
        }
            
        public IEnumerable<T> ObterTodos()
        {
            IEnumerable<T> lista;
            try
            {
                lista = Rep.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter os dados da lista do Repositorio", ex);
            }
            return lista;
        }
        public void Salvar(T entidade)
        {
            try
            {
                Rep.Inserir(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar a Entidade no Banco de dados", ex);
            }


        }
        protected T ObterPorId(int id)
        {
            try
            {
                return Rep.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar a Entidade no Banco de dados", ex);
            }
        }
    }

}
