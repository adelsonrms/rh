//Namespaces de acesso a dados
//Usar somente o necessário
using RH.Infra.Data;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FCStore.Infra.StoreContext.DataContext
{
    public enum ConnectionState
    {
        Opened,
        Close
    }
    /// <summary>
    ///     Implementa as funcionalidades que interage com o banco de dados.
    /// </summary>
    public class FcDbContext : IDisposable
    {
        /// <summary>
        ///     Variavel local privada que manterá a instancia da Conexão
        /// </summary>
        private SqlConnection _cnn;

        public string ConnectionStrig { get; private set; }

        /// <summary>
        /// Inicializa um novo conexto do banco de dados com a string pre-configurada nas configurações
        /// </summary>
        public FcDbContext()
        {
            Connect(AppConfig.ConnectionString);
        }
        /// <summary>
        /// Inicializa uma nova conexão com o DB passando uma String de conexa
        /// </summary>
        /// <param name="connectionString"></param>
        public FcDbContext(string connectionString)
        {
            Connect(connectionString);
        }
        
        /// <summary>
        ///     Recupera o status da conexão
        /// </summary>
        public ConnectionState ConnectionState
        {
            get
            {
                if (_cnn != null)
                {
                    return (ConnectionState)_cnn.State;
                }
                else
                {
                    return ConnectionState.Close;
                };
            }
        }

        /// <summary>
        ///     Retorna a conexão aberta. Caso nao esteja aberta, abre-a
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                if (_cnn == null) Connect(); return _cnn;
            }
        }

        /// <summary>
        /// Inicializa uma conexão com a mesma string ja utilizada na instancia
        /// </summary>
        /// <returns></returns>
        private SqlConnection Connect()
        {
            return Connect(this.ConnectionStrig);
        }

        /// <summary>
        /// Efetua a conexão com o banco de dados atraves da string de conexão armazenada no Web.Config
        /// </summary>
        /// <param name="stringConnection">Recebe uma conection String utilizada para conexão</param>
        /// <returns>Retorna um objeto SqlConnection aberto (ou não em caso de falha)</returns>
        private SqlConnection Connect(string stringConnection)
        {
            try
            {
                ConnectionStrig = stringConnection;
                if (this.ConnectionState == ConnectionState.Close)
                {
                    _cnn = new SqlConnection(stringConnection);
                }
                _cnn.Open();
            }
            catch
            {
                _cnn = null;
            }
            return _cnn;
        }

        /// <summary>
        ///     Inicializa uma conexão permitindo forçar a criação de uma nova instancia
        /// </summary>
        /// <param name="bForceNew">Se true, a conexão atual será finalizada e uma nova será aberta</param>
        /// <returns></returns>
        private SqlConnection GetConnection(bool bForceNew = false)
        {
            if (bForceNew) CloseConnection();
            ;
            return Connect();
        }

        /// <summary>
        ///     Finaliza a conexão atualmente ativa
        /// </summary>
        /// <returns></returns>
        private bool CloseConnection()
        {
            var ret = true;
            try
            {
                _cnn?.Close(); //null propagation
            }
            catch
            {
                ret = false;
            }
            finally
            {
                _cnn = null; _cnn?.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// Fecha e descarrega a conexao 
        /// </summary>
        public void Dispose()
        {
            CloseConnection();
        }

        public bool ExecuteCommand(SqlCommand cmdCommand)
        {
            var tran = Connection.BeginTransaction();

            try
            {
                cmdCommand.Transaction = tran;
                cmdCommand.Connection = Connection;
                cmdCommand.BeginExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
        }
    }
}