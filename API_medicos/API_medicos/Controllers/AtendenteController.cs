using API_medicos.Data;
using API_medicos.Models;
using API_medicos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_medicos.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AtendenteController : ControllerBase
    {
        private AtendenteService atendenteService = new AtendenteService();

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<AtendenteModel> GetAll()
        {
            return atendenteService.GetAll();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public AtendenteModel Get(int id)
        {
            return atendenteService.Get(id);
        }

        [HttpPost]
        [Route("[controller]")]
        public void Create([FromBody] AtendenteModel atendente)
        {
            atendenteService.Create(atendente);
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        public void Update(int id, [FromBody] AtendenteModel atendente)
        {
            atendenteService.Update(id, atendente);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public void Delete(int id)
        {
            atendenteService.Delete(id);
        }
    }
}
