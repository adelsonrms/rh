using System;
using System.Configuration;
using FCStore.Infra.StoreContext.DataContext;
using RH.Domain.Repositories;
using RH.Infra.Data.DBContexts;
using RH.Infra.Data.Repositories;

namespace ERP.RH.Application
{
    public  class DataContext:IDisposable
    {
        //Inicializa o controller ja conectado ao DB
        private readonly TecnunDbContext _db = new TecnunDbContext();

        //Expoe o contexto para a controller
        protected virtual TecnunDbContext Db
        {
            get { return this._db; }
        }
        /// <summary>
        /// Inicializa um repositório generico
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <returns></returns>
        protected IGenericRepository<TEntidade> InicializaRepositorio<TEntidade>() where TEntidade : class
        {
            try
            {
                return new Repositorio<TEntidade>(this._db);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
    public class DataDapperContext : IDisposable
    {
        string ConnectionString = string.Empty;
        public DataDapperContext()
        {
            _db = new FcDbContext();
        }
        public DataDapperContext(string connectionString)
        {
            ConnectionString = connectionString;
            _db = new FcDbContext(connectionString);
        }
        //Inicializa o controller ja conectado ao DB
        private FcDbContext _db;

        //Expoe o contexto para a controller
        protected virtual FcDbContext Db
        {
            get { return this._db; }
        }
        /// <summary>
        /// Inicializa um repositório generico
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <returns></returns>
        protected DapperRepository<TEntidade> InicializaRepositorio<TEntidade>() where TEntidade : class
        {
            try
            {
                if (_db==null) { _db = new FcDbContext();}

                return new DapperRepository<TEntidade>(_db);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
