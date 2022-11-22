using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API_medicos.Models;
using API_medicos.Services;
using Microsoft.AspNetCore.Authorization;

namespace API_medicos.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private MedicoService medicoService = new MedicoService();

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<MedicoModel> GetAll()
        {
            return medicoService.GetAll();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public MedicoModel Get(int id)
        {
            return medicoService.Get(id);
        }

        [HttpPost]
        [Route("[controller]")]
        public MedicoModel Create([FromBody] MedicoModel medico)
        {
            return medicoService.Create(medico);
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        public MedicoModel Update(int id, [FromBody] MedicoModel medico)
        {
            return medicoService.Update(id, medico);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public ModelBase Delete(int id)
        {
            return medicoService.Delete(id);
        }
    }
}