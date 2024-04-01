using Microsoft.AspNetCore.Mvc;

using ampare.api.Models;
using ampare.api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ampare.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        // definindo variável de contexto a partir do banco
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cadastro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetCadastro()
        {
            return await _context.Cadastros.ToListAsync();
        }

        // GET: api/Cadastro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cadastro>> GetCadastro(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return cadastro;
        }

        // POST: api/Cadastro
        [HttpPost]
        public async Task<ActionResult<Cadastro>> Create(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Cadastros.Add(cadastro);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCadastro", new { id = cadastro.Id }, cadastro);
            }
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Cadastro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != cadastro.Id)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Cadastro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            _context.Cadastros.Remove(cadastro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
