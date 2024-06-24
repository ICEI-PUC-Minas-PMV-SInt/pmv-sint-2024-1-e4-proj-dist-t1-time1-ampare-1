using Microsoft.AspNetCore.Mvc;
using ampare.api.Models;
using ampare.api.Repositories;
using Microsoft.EntityFrameworkCore;
using ampare.api.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace ampare.api.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoVoluntarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjetoVoluntarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjetoVoluntario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoVoluntario>>> GetProjetoVoluntarios()
        {
            return await _context.ProjetoVoluntario.Include(pv => pv.Projeto)
                                                    .Include(pv => pv.Voluntario)
                                                    .ToListAsync();
        }

        // GET: api/ProjetoVoluntario/5
        [HttpGet("{projetoId}/{voluntarioId}")]
        public async Task<ActionResult<ProjetoVoluntario>> GetProjetoVoluntario(int projetoId, int voluntarioId)
        {
            var projetoVoluntario = await _context.ProjetoVoluntario
                .Include(pv => pv.Projeto)
                .Include(pv => pv.Voluntario)
                .FirstOrDefaultAsync(pv => pv.ProjetoId == projetoId && pv.VoluntarioId == voluntarioId);

            if (projetoVoluntario == null)
            {
                return NotFound();
            }

            return projetoVoluntario;
        }

        // POST: api/ProjetoVoluntario
        [HttpPost]
        public async Task<ActionResult<ProjetoVoluntario>> PostProjetoVoluntario(ProjetoVoluntario projetoVoluntario)
        {
            _context.ProjetoVoluntario.Add(projetoVoluntario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjetoVoluntario", new { projetoId = projetoVoluntario.ProjetoId, voluntarioId = projetoVoluntario.VoluntarioId }, projetoVoluntario);
        }

        // DELETE: api/ProjetoVoluntario/5
        [HttpDelete("{projetoId}/{voluntarioId}")]
        public async Task<IActionResult> DeleteProjetoVoluntario(int projetoId, int voluntarioId)
        {
            var projetoVoluntario = await _context.ProjetoVoluntario
                .FirstOrDefaultAsync(pv => pv.ProjetoId == projetoId && pv.VoluntarioId == voluntarioId);

            if (projetoVoluntario == null)
            {
                return NotFound();
            }

            _context.ProjetoVoluntario.Remove(projetoVoluntario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
