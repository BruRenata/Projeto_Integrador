using API_medicos.Models;
using API_medicos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_medicos.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private ExameService exameService = new ExameService();

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<ExameModel> GetAll()
        {
            return exameService.GetAll();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public ExameModel Get(int id)
        {
            return exameService.Get(id);
        }

        [HttpGet]
        [Route("[controller]/Ordem/MenosPedido")]
        public IEnumerable<ExameModel> GetAllMenosPedidoParaMaisPedido()
        {
            return exameService.GetAllMenosPedidoParaMaisPedido();
        }

        [HttpGet]
        [Route("[controller]/Ordem/MaisPedido")]
        public IEnumerable<ExameModel> GetAllMaisPedidoParaMenosPedido()
        {
            return exameService.GetAllMaisPedidoParaMenosPedido();
        }

        [HttpPost]
        [Route("[controller]")]
        public void Create([FromBody] ExameModel exame)
        {
            exameService.Create(exame);
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        public void Update(int id, [FromBody] ExameModel exame)
        {
            exameService.Update(id, exame);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public void Delete(int id)
        {
            exameService.Delete(id);
        }
    }
}
