using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_medicos.Models
{
    public class ExameModel : ModelBase
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public long ID_Consulta { get; set; }
    }
}
