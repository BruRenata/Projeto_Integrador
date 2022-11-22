using API_medicos.Data;
using API_medicos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_medicos.Services
{
    public class PacienteService
    {
        public IEnumerable<PacienteModel> GetAll()
        {
            List<PacienteModel> pacientes = new List<PacienteModel>();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from pacientes";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    PacienteModel paciente = new PacienteModel();
                    paciente.ID = lidos.GetInt32("id");
                    paciente.Nome = lidos.GetString("nome");
                    pacientes.Add(paciente);
                }
            }

            return pacientes;
        }

        public PacienteModel Get(int id)
        {
            PacienteModel paciente = new PacienteModel();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from pacientes where id = @id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@id", id);
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                if (lido.Read())
                {
                    paciente.ID = lido.GetInt32("id");
                    paciente.Nome = lido.GetString("nome");
                }
            }

            return paciente;
        }

        public PacienteModel GetHistorico(int id)
        {
            PacienteModel paciente = new PacienteModel();
            List<ConsultaModel> consultas = new List<ConsultaModel>();
            List<ExameModel> exames = new List<ExameModel>();
            List<MedicoModel> medicos = new List<MedicoModel>();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from pacientes where id = @id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@id", id);
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                if (lido.Read())
                {
                    paciente.ID = lido.GetInt32("id");
                    paciente.Nome = lido.GetString("nome");
                }
            }

            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from consultas where paciente_id = @paciente_id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@paciente_id", id);
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                while (lido.Read())
                {
                    ConsultaModel consulta = new ConsultaModel();
                    consulta.ID = lido.GetInt32("id");
                    consulta.ID_Paciente = lido.GetInt32("paciente_id");
                    consulta.ID_Medico = lido.GetInt32("medico_id");
                    consulta.DataConsulta = lido.GetDateTime("data_consulta");
                    consulta.Observacao = lido.GetString("observacao");
                    consultas.Add(consulta);
                }
            }

            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from exames where consulta_id in (@ids_consultas)";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@ids_consultas", string.Join(",", consultas.Select(C => C.ID)));
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();
                while (lido.Read())
                {
                    ExameModel exame = new ExameModel();
                    exame.ID = lido.GetInt32("id");
                    exame.Tipo = lido.GetString("tipo");
                    exame.Descricao = lido.GetString("descricao");
                    exame.ID_Consulta = lido.GetInt32("consulta_id");
                    exames.Add(exame);
                }
            }

            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from medicos where id in (@ids_medicos)";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@ids_medicos", string.Join(",", consultas.Select(C => C.ID_Medico)));
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();
                while (lido.Read())
                {
                    MedicoModel medico = new MedicoModel();
                    medico.ID = lido.GetInt32("id");
                    medico.Nome = lido.GetString("nome");
                    medicos.Add(medico);
                }
            }

            paciente.Historico = Utilitarios.PacienteUtils.GerarHistoricoPaciente(paciente, consultas, exames, medicos);
            return paciente;
        }

        public void Create(PacienteModel paciente)
        {
            using (Connection bancoDados = new Connection())
            {
                string sql = "insert into pacientes (nome) values (@nome)";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@nome", paciente.Nome);
                bancoDados.Conexao.Open();
                bancoDados.SQLCommand.ExecuteReader();
            }
        }

        public void Update(int id, PacienteModel paciente)
        {
            try
            {
                using (Connection bancoDados = new Connection())
                {
                    string sql = "update pacientes set nome = @Nome where id = @Id";
                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@Nome", paciente.Nome);
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
                    string sql = "delete from pacientes where id = @id";
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
