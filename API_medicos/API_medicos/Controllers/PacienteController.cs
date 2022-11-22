using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API_medicos.Models;
using Microsoft.AspNetCore.Authorization;
using API_medicos.Services;

namespace API_medicos.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private PacienteService pacienteService = new PacienteService();

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<PacienteModel> GetAll()
        {
            return pacienteService.GetAll();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public PacienteModel Get(int id)
        {
            return pacienteService.Get(id);
        }

        [HttpGet]
        [Route("[controller]/historico/{id}")]
        public PacienteModel GetHistorico(int id)
        {
            return pacienteService.GetHistorico(id);
        }

        [HttpPost]
        [Route("[controller]")]
        public void Create([FromBody] PacienteModel paciente)
        {
            pacienteService.Create(paciente);
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        public void Update(int id, [FromBody] PacienteModel paciente)
        {
            pacienteService.Update(id, paciente);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public void Delete(int id)
        {
            pacienteService.Delete(id);
        }
    }
}