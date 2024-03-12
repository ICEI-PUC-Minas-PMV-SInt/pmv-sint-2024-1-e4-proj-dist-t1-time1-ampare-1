using Microsoft.AspNetCore.Mvc;

using ampare.api.Models;
using ampare.api.Repositories;

namespace ampare.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        public CadastroController()
        {
        }

        [HttpGet]
        public ActionResult<List<Cadastro>> GetAll() =>
            CadastroInMemory.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Cadastro> Get(int id)
        {
            var cadastro = CadastroInMemory.Get(id);

            if (cadastro == null)
                return NotFound();

            return cadastro;
        }

        [HttpPost]
        public IActionResult Create(Cadastro cadastro)
        {
            CadastroInMemory.Add(cadastro);
            return CreatedAtAction(nameof(Get), new { id = cadastro.Id }, cadastro);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Cadastro cadastro)
        {
            if (id != cadastro.Id)
                return BadRequest();

            var existingCadastro = CadastroInMemory.Get(id);
            if (existingCadastro is null)
                return NotFound();

            CadastroInMemory.Update(cadastro);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cadastro = CadastroInMemory.Get(id);

            if (cadastro is null)
                return NotFound();

            CadastroInMemory.Delete(id);

            return NoContent();
        }
    }
}
