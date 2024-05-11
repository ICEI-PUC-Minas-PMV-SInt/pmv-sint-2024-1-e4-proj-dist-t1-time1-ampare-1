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
    public class CadastroController : ControllerBase
    {
        // definindo variável de contexto a partir do banco
        private readonly AppDbContext _context;
        private readonly CnpjService _cnpjService;

        public CadastroController(AppDbContext context, CnpjService cnpjService)
        {
            _context = context;
            _cnpjService = cnpjService;
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
            try
            {
                if (cadastro.Cnpj != null)
                {
                    var companyName = await _cnpjService.GetCompanyName(cadastro.Cnpj);
                    cadastro.RazaoSocial = companyName;
                }

                _context.Cadastros.Add(cadastro);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCadastro", new { id = cadastro.Id }, cadastro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar cadastro: {ex.Message}");
            }
        }

        // PUT: api/Cadastro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cadastro cadastro)
        {
            try
            {
                // Verifica se o ID passado na rota corresponde ao ID do cadastro
                if (id != cadastro.Id)
                {
                    return BadRequest("O ID fornecido não corresponde ao ID do cadastro.");
                }

                if (cadastro.Cnpj != null)
                {
                    var companyName = await _cnpjService.GetCompanyName(cadastro.Cnpj);
                    cadastro.RazaoSocial = companyName;
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

                return Ok("Cadastro atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar cadastro: {ex.Message}");
            }
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
