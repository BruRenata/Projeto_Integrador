using API_medicos.Data;
using API_medicos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace API_medicos.Services
{
    public class MedicoService
    {
        public IEnumerable<MedicoModel> GetAll()
        {
            List<MedicoModel> medicos = new List<MedicoModel>();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from medicos";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.Conexao.Open();

                MySqlDataReader lidos = bancoDados.SQLCommand.ExecuteReader();

                while (lidos.Read())
                {
                    MedicoModel medico = new MedicoModel();
                    medico.ID = lidos.GetInt32("id");
                    medico.Nome = lidos.GetString("nome");
                    medicos.Add(medico);
                }
            }
            return medicos;
        }

        public MedicoModel Get(int id)
        {
            MedicoModel medico = new MedicoModel();
            using (Connection bancoDados = new Connection())
            {
                string sql = "select * from medicos where id = @id";

                bancoDados.SQLCommand.CommandText = sql;
                bancoDados.SQLCommand.Parameters.AddWithValue("@id", id);
                bancoDados.Conexao.Open();

                MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                if (lido.Read())
                {
                    medico.ID = lido.GetInt32("id");
                    medico.Nome = lido.GetString("nome");
                }
            }

            return medico;
        }

        public MedicoModel Create(MedicoModel medico)
        {
            try
            {
                Utilitarios.Validacoes.CPFFormatoCorreto(medico.CPF);
                Utilitarios.Validacoes.CPFValido(medico.CPF);

                using (Connection bancoDados = new Connection())
                {
                    string sql = "select from medicos where cpf = @cpf";

                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@cpf", medico.CPF);
                    bancoDados.Conexao.Open();
                    bancoDados.SQLCommand.ExecuteReader();

                    MySqlDataReader lido = bancoDados.SQLCommand.ExecuteReader();

                    if (lido.Read())
                    {
                        throw new Exception("O CPF informado já está em uso.");
                    }
                }

                using (Connection bancoDados = new Connection())
                {
                    string sql = "insert into medicos (nome) values (@nome)";

                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@nome", medico.Nome);
                    bancoDados.Conexao.Open();
                    bancoDados.SQLCommand.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                medico.TemErro = true;
                medico.Erro = e.Message;
            }
            return medico;
        }

        public MedicoModel Update(int id, MedicoModel medico)
        {
            try
            {
                using (Connection bancoDados = new Connection())
                {
                    string sql = "update medicos set nome = @Nome where id = @Id";
                    bancoDados.SQLCommand.CommandText = sql;
                    bancoDados.SQLCommand.Parameters.AddWithValue("@Nome", medico.Nome);
                    bancoDados.SQLCommand.Parameters.AddWithValue("@Id", id);
                    bancoDados.Conexao.Open();
                    bancoDados.SQLCommand.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao Atualizar: {e.Message}.");
            }
            return medico;
        }

        public ModelBase Delete(int id)
        {
            ModelBase retorno = new ModelBase();
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
                retorno.Mensagem = "Medico de id excluido com sucesso!";
            }
            catch (Exception e)
            {
                retorno.TemErro = true;
                retorno.Erro = $"Erro ao Deletar: {e.Message}.";
            }
            return retorno;
        }
    }
}
