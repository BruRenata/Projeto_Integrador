namespace API_medicos.Models
{
    public class MedicoModel : ModelBase
    {
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
    }
}
