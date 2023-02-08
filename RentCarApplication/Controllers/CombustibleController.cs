using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombustibleController : ControllerBase
    {
        private readonly DB_Context _context;

        public CombustibleController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Combustible>>> GetCombustibles()
        {
            return await _context.Combustibles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Combustible>> GetCombustible(int id)
        {
            var combustible = await _context.Combustibles.FindAsync(id);
            if (combustible == null)
            {
                return NotFound();
            }
            return combustible;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCombustible(int id, Combustible combustible)
        {
            if (id != combustible.Id_Combustible)
            {
                return BadRequest();
            }
            _context.Entry(combustible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CombustibleExists(id))
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
        public async Task<ActionResult<Combustible>> PostCliente(Combustible combustible)
        {
            _context.Combustibles.Add(combustible);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCombustible", new { id = combustible.Id_Combustible }, combustible);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCombustible(int id)
        {
            var combustible = await _context.Combustibles.FindAsync(id);
            if (combustible == null)
            {
                return NotFound();
            }
            _context.Combustibles.Remove(combustible);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CombustibleExists(int id)
        {
            return _context.Combustibles.Any(e => e.Id_Combustible == id);
        }
    }
}
