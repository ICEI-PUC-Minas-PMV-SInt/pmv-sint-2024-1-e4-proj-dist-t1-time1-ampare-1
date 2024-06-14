using Microsoft.AspNetCore.Mvc;
using ampare.api.Models;
using Microsoft.EntityFrameworkCore;
using ampare.api.Services;
using Newtonsoft.Json;

namespace ampare.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoluntariosController : ControllerBase
    {
        // definindo vari�vel de contexto a partir do banco
        private readonly AppDbContext _context;

        public VoluntariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cadastro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voluntario>>> GetVoluntario()
        {
            return await _context.Voluntarios.ToListAsync();
        }

        // GET: api/Voluntario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voluntario>> GetVoluntario(int id)
        {
            var voluntario = await _context.Voluntarios.FindAsync(id);

            if (voluntario == null)
            {
                return NotFound();
            }

            return voluntario;
        }

        // POST: api/Voluntario
        [HttpPost]
        public async Task<ActionResult<Voluntario>> Create(Voluntario voluntario)
        {         

            _context.Voluntarios.Add(voluntario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoluntario", new { id = voluntario.VoluntarioId }, voluntario);
        }

        // PUT: api/voluntario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Voluntario voluntario)
        {
            try
            {
                // Verifica se o ID passado na rota corresponde ao ID do cadastro
                if (id != voluntario.VoluntarioId)
                {
                    return BadRequest("O ID fornecido n�o corresponde ao ID do cadastro.");
                }

                _context.Entry(voluntario).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != voluntario.VoluntarioId)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok("Cadastro atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar cadastro: {ex.Message}");
            }
        }


        // DELETE: api/voluntario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var voluntario = await _context.Voluntarios.FindAsync(id);
            if (voluntario == null)
            {
                return NotFound();
            }

            _context.Voluntarios.Remove(voluntario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
