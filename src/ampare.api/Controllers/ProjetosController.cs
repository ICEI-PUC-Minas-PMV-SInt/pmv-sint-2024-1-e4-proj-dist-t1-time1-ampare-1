using Microsoft.AspNetCore.Mvc;
using ampare.api.Models;
using ampare.api.Repositories;
using Microsoft.EntityFrameworkCore;
using ampare.api.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace ampare.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
           

          private readonly AppDbContext _context;
        

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        
        }

        
        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetAll()
        {
            return await _context.Projetos.ToListAsync();
        }


        // GET: api/projeto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProject(int id)
        {
            var project = await _context.Projetos.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }


        // POST: api/
        [HttpPost]
        public async Task<ActionResult<Projeto>>Create(Projeto projetos) 
        {
            _context.Projetos.Add(projetos);
            await _context.SaveChangesAsync();

             return CreatedAtAction("GetProject", new { id = projetos.ProjetoId }, projetos);

           
        }


        // PUT: api/ong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Projeto projeto)
        {

            try
            {
                // Verifica se o ID passado na rota corresponde ao ID do cadastro
                if (id != projeto.ProjetoId)
                {
                    return BadRequest("O ID fornecido n�o corresponde ao ID do cadastro.");
                }
    

                _context.Entry(projeto).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != projeto.ProjetoId)
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
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return NoContent();
        } 
    }
}

     