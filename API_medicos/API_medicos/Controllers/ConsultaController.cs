using API_medicos.Data;
using API_medicos.Models;
using API_medicos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace API_medicos.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private ConsultaService consultaService = new ConsultaService();

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<ConsultaModel> GetAll()
        {
            return consultaService.GetAll();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public ConsultaModel Get(int id)
        {
            return consultaService.Get(id);
        }

        [HttpGet]
        [Route("[controller]/paciente/{id}")]
        public IEnumerable<ConsultaModel> GetConsultasPorPaciente(int idPaciente)
        {
            return consultaService.GetConsultasPorPaciente(idPaciente);
        }

        [HttpPost]
        [Route("[controller]")]
        public void Create([FromBody] ConsultaModel consulta)
        {
            consultaService.Create(consulta);
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        public void Update(int id, [FromBody] ConsultaModel consulta)
        {
            consultaService.Update(id, consulta);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public void Delete(int id)
        {
            consultaService.Delete(id);
        }
    }
}
