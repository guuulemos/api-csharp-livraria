using Livraria.Infra.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Livraria.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SqlServerConexao { get; set; }

        public DataContext(AppSettings appSettings)
        {
            {
                SqlServerConexao = new SqlConnection(appSettings.ConnectionString);
                SqlServerConexao.Open();
            }

        }
        public void Dispose()
        {

            if (SqlServerConexao.State != ConnectionState.Closed)
            {
                SqlServerConexao.Close();
            }

        }
    }
}
