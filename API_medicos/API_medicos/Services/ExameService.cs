using API_medicos.Data;
using API_medicos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace API_medicos.Services
{
    public class ExameService
    {
        public IEnumerable<ExameModel> GetAll()
        {
            List<ExameModel> exames = new List<ExameModel>();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from exames";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    ExameModel exame = new ExameModel();
                    exame.ID = lidos.GetInt32("id");
                    exame.Tipo = lidos.GetString("tipo");
                    exame.Descricao = lidos.GetString("descricao");
                    exames.Add(exame);
                }
            }
            return exames;
        }

        public ExameModel Get(int id)
        {
            ExameModel exame = new ExameModel();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from exames where id = @id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@id", id);
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                if (lido.Read())
                {
                    exame.ID = lido.GetInt32("id");
                    exame.Tipo = lido.GetString("tipo");
                    exame.Descricao = lido.GetString("descricao");
                }
            }
            return exame;
        }

        public IEnumerable<ExameModel> GetAllMenosPedidoParaMaisPedido()
        {
            List<ExameModel> exames = new List<ExameModel>();
            using (Connection bancoDados = new Connection())
            {
                //MUDAR SQL
                string sql = "select tipo as 'Exames mais realizados', count(tipo) as 'Quantidade' from exames group by tipo order by count(tipo) desc";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    ExameModel exame = new ExameModel();
                    //exame.ID = lidos.GetInt32("id");
                    exame.Tipo = lidos.GetString("Exames mais realizados");
                    //exame.Descricao = lidos.GetString("descricao");
                    exames.Add(exame);
                }
            }
            return exames;
        }

        public IEnumerable<ExameModel> GetAllMaisPedidoParaMenosPedido()
        {
            List<ExameModel> exames = new List<ExameModel>();
            using (Connection bancoDados = new Connection())
            {
                //Mudar SQL
                string sql = "select tipo as 'Exames menos realizados', count(tipo) as 'Quantidade' from exames group by tipo order by count(tipo)";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    ExameModel exame = new ExameModel();
                    //exame.ID = lidos.GetInt32("id");
                    exame.Tipo = lidos.GetString("Exames menos realizados");
                    //exame.Descricao = lidos.GetString("descricao");
                    exames.Add(exame);
                }
            }
            return exames;
        }

        public void Create(ExameModel exame)
        {
            using (Connection bancoDados = new Connection())
            {
                //Mudar esse sql para inserir todas as informações da tabela
                string sql = "insert into exames (tipo, descricao) values (@tipo, @descricao)";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@tipo", exame.Tipo);
                bancoDados.SQLCommand.Parameters.AddWithValue("@descricao", exame.Descricao);
                bancoDados.Conexao.Open();
                bancoDados.SQLCommand.ExecuteReader();
            }
        }

        public void Update(int id, ExameModel exame)
        {
            try
            {
                using (Connection bancoDados = new Connection())
                {
                    //Mudar esse SQL para atualizar todos os campos da tabela
                    string sql = "update exames set tipo = @tipo, descricao = @descricao where id = @id; ";
                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@tipo", exame.Tipo);
                    bancoDados.SQLCommand.Parameters.AddWithValue("@descrição", exame.Descricao);
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
                    string sql = "delete from medicos where id = @id";
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
