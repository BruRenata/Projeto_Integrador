using MySql.Data.MySqlClient;
using System;

namespace API_medicos.Data
{
    public class Connection : IDisposable
    {
        public MySqlConnection Conexao { get; }
        public MySqlCommand SQLCommand { get; }
        private const string ConnectionString = "datasource=localhost;username=root;password=;database=api_medicos";

        public Connection()
        {
            Conexao = new MySqlConnection(ConnectionString);
            SQLCommand = new MySqlCommand("", Conexao);
        }

        public void Dispose()
        {
            Conexao.Close();
        }

    }
}
