using API_medicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_medicos.Utilitarios
{
    public class PacienteUtils
    {
        public static string GerarHistoricoPaciente(PacienteModel paciente, List<ConsultaModel> consultas, List<ExameModel> exames, List<MedicoModel> medicos)
        {
            StringBuilder sbHistorico = new StringBuilder($"Paciente: {paciente.Nome}");
            sbHistorico.AppendLine("Consultas:");
            
            foreach(ConsultaModel consulta in consultas)
            {
                sbHistorico.AppendLine($"Data: {consulta.DataConsulta.ToString("dd/MM/yyyy")} | Medico: {medicos.First(m => m.ID == consulta.ID_Medico).Nome}");
                sbHistorico.AppendLine($"Observações da Consulta: {consulta.Observacao}\n");
                sbHistorico.AppendLine($"Exames Relacionados:");

                foreach (ExameModel exame in exames.Where(e => e.ID_Consulta == consulta.ID))
                {
                    sbHistorico.AppendLine($"  * Tipo: {exame.Tipo} | Descrição: {exame.Descricao}");
                }
                sbHistorico.AppendLine();
            }

            return sbHistorico.ToString();
        }

    }
}
