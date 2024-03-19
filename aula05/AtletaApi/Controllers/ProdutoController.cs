using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtletaApi.Models;

namespace AtletaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        static ProdutoController()
        {
            objetos = new List<Produto>
            {
                new() { Id = "1", Codigo = "123", Descricao = "Coca-cola", Preco = 5.50 },
                new() { Id = "2", Codigo = "125", Descricao = "Pepsi", Preco = 5.0 },
                new() { Id = "3", Codigo = "127", Descricao = "Guarana", Preco = 5.50 }
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            if (objetos == null)
                return NotFound();

            return objetos;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetId(string id)
        {
            var obj = objetos?.FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return NotFound();

            return obj;
        }

        [HttpPost]
        public ActionResult<Produto> Post(Produto obj)
        {
            if (obj.Id == null)
                obj.Id = Guid.NewGuid().ToString();
            
            objetos.Add(obj);
            
            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Produto obj)
        {
            if (id != obj.Id)
                return BadRequest();

            var objOrig = objetos.FirstOrDefault(x => x.Id == id);

            if (objOrig == null)
                return NotFound();

            objOrig.Codigo = obj.Codigo;
            objOrig.Descricao = obj.Descricao;
            objOrig.Preco = obj.Preco;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (objetos == null)
                return NotFound();

            var obj = objetos.FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return NotFound();

            objetos.Remove(obj);

            return NoContent();
        }
        private static List<Produto> objetos;
    }
}