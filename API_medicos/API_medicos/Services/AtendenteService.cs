using API_medicos.Data;
using API_medicos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace API_medicos.Services
{
    public class AtendenteService
    {
        public IEnumerable<AtendenteModel> GetAll()
        {
            List<AtendenteModel> atendentes = new List<AtendenteModel>();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from atendentes";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    AtendenteModel atendente = new AtendenteModel();
                    atendente.ID = lidos.GetInt32("id");
                    atendente.Nome = lidos.GetString("nome");
                    atendentes.Add(atendente);
                }
            }

            return atendentes;
        }

        public AtendenteModel Get(int id)
        {
            AtendenteModel atendente = new AtendenteModel();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from atendentes where id = @id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@id", id);
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                if (lido.Read())
                {
                    atendente.ID = lido.GetInt32("id");
                    atendente.Nome = lido.GetString("nome");
                }
            }

            return atendente;
        }

        public void Create(AtendenteModel atendente)
        {
            using (Connection bancoDados = new Connection())
            {
                string sql = "insert into atendentes (nome) values (@nome)";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@nome", atendente.Nome);
                bancoDados.Conexao.Open();
                bancoDados.SQLCommand.ExecuteReader();
            }
        }

        public void Update(int id, AtendenteModel atendente)
        {
            try
            {
                using (Connection bancoDados = new Connection())
                {
                    string sql = "update atendentes set nome = @Nome where id = @Id";
                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@Nome", atendente.Nome);
                    bancoDados.SQLCommand.Parameters.AddWithValue("@Id", id);
                    bancoDados.Conexao.Open();
                    bancoDados.SQLCommand.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao Atualizar: {e.Message}.");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (Connection bancoDados = new Connection())
                {
                    string sql = "delete from atendentes where id = @id";
                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@Id", id);
                    bancoDados.Conexao.Open();
                    bancoDados.SQLCommand.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao Deletar: {e.Message}.");
            }
        }
    }
}
