using API_medicos.Data;
using API_medicos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace API_medicos.Services
{
    public class ConsultaService
    {
        public IEnumerable<ConsultaModel> GetAll()
        {
            List<ConsultaModel> consultas = new List<ConsultaModel>();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from consultas";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    ConsultaModel consulta = new ConsultaModel();
                    consulta.ID = lidos.GetInt32("id");
                    consulta.ID_Paciente = lidos.GetInt32("paciente_id");
                    consulta.ID_Medico = lidos.GetInt32("medico_id");
                    consulta.Observacao = lidos.GetString("observacao");
                    consulta.DataConsulta = lidos.GetDateTime("data_consulta");
                    consultas.Add(consulta);
                }
            }

            return consultas;
        }

        public ConsultaModel Get(int id)
        {
            ConsultaModel consulta = new ConsultaModel();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from consultas where id = @id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@id", id);
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                if (lido.Read())
                {
                    consulta.ID = lido.GetInt32("id");
                    consulta.ID_Paciente = lido.GetInt32("paciente_id");
                    consulta.ID_Medico = lido.GetInt32("medico_id");
                    consulta.Observacao = lido.GetString("observacao");
                    consulta.DataConsulta = lido.GetDateTime("data_consulta");
                }
            }

            return consulta;
        }

        public IEnumerable<ConsultaModel> GetConsultasPorPaciente(int idPaciente)
        {
            List<ConsultaModel> consultas = new List<ConsultaModel>();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from consultas where paciente_id = @paciente_id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@paciente_id", idPaciente);
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    ConsultaModel consulta = new ConsultaModel();
                    consulta.ID = lidos.GetInt32("id");
                    consulta.ID_Paciente = lidos.GetInt32("paciente_id");
                    consulta.ID_Medico = lidos.GetInt32("medico_id");
                    consulta.Observacao = lidos.GetString("observacao");
                    consulta.DataConsulta = lidos.GetDateTime("data_consulta");
                    consultas.Add(consulta);
                }
            }

            return consultas;
        }

        public void Create(ConsultaModel consulta)
        {
            using (Connection bancoDados = new Connection())
            {
                string sql = "insert into consultas (paciente_id, medico_id, observacao, data_consulta) values (@paciente_id, @medico_id, @observacao, @data_consulta)";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@paciente_id", consulta.ID_Paciente);
                bancoDados.SQLCommand.Parameters.AddWithValue("@medico_id", consulta.ID_Medico);
                bancoDados.SQLCommand.Parameters.AddWithValue("@observacao", consulta.Observacao);
                bancoDados.SQLCommand.Parameters.AddWithValue("@data_consulta", consulta.DataConsulta);
                bancoDados.Conexao.Open();
                bancoDados.SQLCommand.ExecuteReader();
            }
        }

        public void Update(int id, ConsultaModel consulta)
        {
            try
            {
                using (Connection bancoDados = new Connection())
                {
                    string sql = "update consultas set paciente_id = @paciente_id, medico_id = @medico_id, observacao = @observacao, data_consulta = @data_consulta where id = @Id";
                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@paciente_id", consulta.ID_Paciente);
                    bancoDados.SQLCommand.Parameters.AddWithValue("@medico_id", consulta.ID_Medico);
                    bancoDados.SQLCommand.Parameters.AddWithValue("@observacao", consulta.Observacao);
                    bancoDados.SQLCommand.Parameters.AddWithValue("@data_consulta", consulta.DataConsulta);
                    bancoDados.SQLCommand.Parameters.AddWithValue("@Id", consulta.ID);
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
                    string sql = "delete from consultas where id = @id";
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
