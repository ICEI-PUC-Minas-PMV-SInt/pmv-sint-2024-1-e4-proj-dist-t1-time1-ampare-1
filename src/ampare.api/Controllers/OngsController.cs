using Microsoft.AspNetCore.Mvc;
using ampare.api.Models;
using ampare.api.Repositories;
using Microsoft.EntityFrameworkCore;
using ampare.api.Services;
using Newtonsoft.Json;

namespace ampare.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OngController : ControllerBase
    {
        // definindo vari�vel de contexto a partir do banco
        private readonly AppDbContext _context;
        private readonly CnpjService _cnpjService;

        public OngController(AppDbContext context, CnpjService cnpjService)
        {
            _context = context;
            _cnpjService = cnpjService;
        }

        // GET: api/Cadastro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ong>>> GetOng()
        {
            return await _context.Ongs.ToListAsync();
        }

        // GET: api/Ong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ong>> GetOng(int id)
        {
            var ong = await _context.Ongs.FindAsync(id);

            if (ong == null)
            {
                return NotFound();
            }

            return ong;
        }

        // POST: api/Ong
        [HttpPost]
        public async Task<ActionResult<Ong>> Create(Ong ong)
        {
            try
            {
                /*
                if (ong.Cnpj != null)
                {
                    var companyName = await _cnpjService.GetCompanyName(ong.Cnpj);
                    ong.RazaoSocial = companyName;
                }
                */

                _context.Ongs.Add(ong);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOng", new { id = ong.OngId }, ong);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar ong: {ex.Message}");
            }
        }

        // PUT: api/ong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ong ong)
        {
            try
            {
                // Verifica se o ID passado na rota corresponde ao ID do cadastro
                if (id != ong.OngId)
                {
                    return BadRequest("O ID fornecido n�o corresponde ao ID do cadastro.");
                }

                if (ong.Cnpj != null)
                {
                    var companyName = await _cnpjService.GetCompanyName(ong.Cnpj);
                    ong.RazaoSocial = companyName;
                }

                _context.Entry(ong).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != ong.OngId)
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

        // DELETE: api/ong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ong = await _context.Ongs.FindAsync(id);
            if (ong == null)
            {
                return NotFound();
            }

            _context.Ongs.Remove(ong);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
