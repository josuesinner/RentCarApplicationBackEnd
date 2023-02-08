using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspeccionController : ControllerBase
    {
        private readonly DB_Context _context;

        public InspeccionController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspeccion>>> GetInspecciones()
        {
            return await _context.Inspeccions.Include(x => x.Vehiculo).Include(x => x.Cliente).Include(x => x.Empleado).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inspeccion>> GetInspeccion(int id)
        {
            var inspeccion = await _context.Inspeccions.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }
            return inspeccion;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspeccion(int id, Inspeccion inspeccion)
        {
            if (id != inspeccion.Id_Transaccion)
            {
                return BadRequest();
            }
            _context.Entry(inspeccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspeccionExists(id))
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
        public async Task<ActionResult<Inspeccion>> PostInspeccion(Inspeccion inspeccion)
        {
            _context.Inspeccions.Add(inspeccion);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetInspeccion", new { id = inspeccion.Id_Transaccion }, inspeccion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspeccion(int id)
        {
            var inspeccion = await _context.Inspeccions.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }
            _context.Inspeccions.Remove(inspeccion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool InspeccionExists(int id)
        {
            return _context.Inspeccions.Any(e => e.Id_Transaccion == id);
        }
    }
}
