using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtletaModel;
using AtletaInfra.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace AtletaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtletaController : ControllerBase
    {
        public AtletaController()
        {
            dao = new AtletaDAO()
        }

        [HttpGet]
        public ActionResult<IEnumerable<Atleta>> Get()
        {
            var objetos = dao.RetornarTodos();
            if (objetos == null)
                return NotFound();

            return OK(objetos);
        }

        [HttpGet("{id}")]
        public ActionResult<Atleta> GetId(string id)
        {
            var obj = dao.RetornarPorId(id);

            if (obj == null)
                return NotFound();

            return obj;
        }

        [HttpPost]
        public ActionResult<Atleta> Post(Atleta obj)
        {
            if (obj.Id == null)
                obj.Id = Guid.NewGuid().ToString();
            
            dao.Inserir(obj);

            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Atleta obj)
        {
            if (id != obj.Id)
                return BadRequest();
        
            var objOrig = dao.RetornarPorId(id);

            if (objOrig == null)
                return NotFound();

            objOrig.Altura = obj.Altura;
            objOrig.Nome = obj.Nome;
            objOrig.Peso = obj.Peso;

            dao.Alterar(obj);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (objetos == null)
                return NotFound();
        
            var obj = dao.Excluir(id);

            return NoContent();
        }

        private readonly AtletaDAO dao = null;
    }
}