using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_medicos.Models
{
    public class ConsultaModel : ModelBase
    {
        public long ID_Medico { get; set; }
        public long ID_Paciente { get; set; }
        public string Observacao { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}
