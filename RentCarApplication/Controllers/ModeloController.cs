using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly DB_Context _context;

        public ModeloController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelos>>> GetModeloses()
        {
            return await _context.Modelos.Include(x=>x.Marca).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelos>> GetModelos(int id)
        {
            var modelos = await _context.Modelos.FindAsync(id);
            if (modelos == null)
            {
                return NotFound();
            }
            return modelos;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelos(int id, Modelos modelos)
        {
            if (id != modelos.Id_Modelo)
            {
                return BadRequest();
            }
            _context.Entry(modelos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelosExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Modelos>> PostModelos(Modelos modelos)
        {
            _context.Modelos.Add(modelos);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetModelos", new { id = modelos.Id_Modelo }, modelos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelos(int id)
        {
            var modelos = await _context.Modelos.FindAsync(id);
            if (modelos == null)
            {
                return NotFound();
            }
            _context.Modelos.Remove(modelos);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ModelosExists(int id)
        {
            return _context.Modelos.Any(e => e.Id_Modelo == id);
        }
    }
}
