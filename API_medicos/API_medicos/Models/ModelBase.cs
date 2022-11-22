using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_medicos.Models
{
    public class ModelBase
    {
        public long ID { get; set; }
        public string Erro { get; set; }
        public bool TemErro { get; set; }
        public string Mensagem { get; set; }
    }
}
