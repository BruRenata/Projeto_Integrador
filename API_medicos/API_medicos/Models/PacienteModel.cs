using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_medicos.Models
{
    public class PacienteModel : ModelBase
    {
        public string Nome { get; set; }
        public string Historico { get; set; }
    }
}