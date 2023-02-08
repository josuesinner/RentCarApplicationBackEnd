using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly DB_Context _context;

        public MarcaController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marcas>>> GetMarcases()
        {
            return await _context.Marcas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marcas>> GetMarcas(int id)
        {
            var marcas = await _context.Marcas.FindAsync(id);
            if (marcas == null)
            {
                return NotFound();
            }
            return marcas;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarcas(int id, Marcas marcas)
        {
            if (id != marcas.Id_Marca)
            {
                return BadRequest();
            }
            _context.Entry(marcas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcasExists(id))
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
        public async Task<ActionResult<Marcas>> PostMarcas(Marcas marcas)
        {
            _context.Marcas.Add(marcas);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMarcas", new { id = marcas.Id_Marca }, marcas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarcas(int id)
        {
            var marcas = await _context.Marcas.FindAsync(id);
            if (marcas == null)
            {
                return NotFound();
            }
            _context.Marcas.Remove(marcas);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool MarcasExists(int id)
        {
            return _context.Marcas.Any(e => e.Id_Marca == id);
        }
    }
}
