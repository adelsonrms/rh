using Dapper;
using FCStore.Infra.StoreContext.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static RH.Domain.Generic.DbEntity<object>;


// ReSharper disable once CheckNamespace
namespace RH.Infra.Data.DBContexts
{
    public class DapperRepository<TEntity>
    {
        private readonly FcDbContext _context;
        string table;
        string sqlCommand;
        public DapperRepository()
        {
            _context = new FcDbContext(AppConfig.ConnectionString);
        }
        public DapperRepository(FcDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TEntity> ObterTodos()
        {
            var Entity = new EntityBase<TEntity>(null, table);
            sqlCommand = Entity.Select(true);
            return _context.Connection.Query<TEntity>(sqlCommand, new {},commandType:CommandType.Text);
        }
        public bool Alterar(TEntity obj)
        {
            var ok = false;
            try
            {
                ok = true;
            }
            catch (Exception ex)
            {
            }
            return ok;
        }
        public TEntity ObterPorId(int id)
        {
            var Entity = new EntityBase<TEntity>(null, table);
            string sqlCommand = Entity.SelectById(id.ToString());
            return _context.Connection.Query<TEntity>(sqlCommand, new {},commandType: CommandType.Text).FirstOrDefault();
        }
        public TEntity Inserir(object obj)
        {
            TEntity retorno = default(TEntity);
            EntityBase<TEntity> entity = new EntityBase<TEntity>(obj, table); ;
            try
            {
                //Salva o objeto
                _context.Connection.Query<TEntity>(entity.Insert());
                //Recupera o objeto salvo
                retorno = _context.Connection.Query<TEntity>(entity.Select()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var EnvironmentDetails = new {
                    Context = _context,
                    Entity = entity,
                    Entidade = obj,
                    Tabela = table,
                    Retorno = retorno,
                    Operacao = "INSERT",
                    SQLCrudCommands = entity.SqlCrud
                };

                throw new FcStoreDbContextException("Ocorreu um exceção inesperada. Consulte log ,InnerException ou EnvironmentDetails para detalhes", ex, EnvironmentDetails);
            }
            return retorno;
        }
        public TEntity ObtemPorNome(dynamic obj, string table) {
            return ObtemPor(obj, table, "Nome", obj.Nome);
        }
        public TEntity ObtemPor(dynamic obj, string table, string coluna, string valor)
        {
            var Entity = new EntityBase<TEntity>(obj, table);
            string cmd = Entity.SelectByCollumn(coluna, valor);
            return _context.Connection.Query<TEntity>(cmd).FirstOrDefault();
        }
    }
}
