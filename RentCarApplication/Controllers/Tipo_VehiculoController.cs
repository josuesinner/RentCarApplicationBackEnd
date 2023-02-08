using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_VehiculoController : ControllerBase
    {
        private readonly DB_Context _context;

        public Tipo_VehiculoController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_Vehiculo>>> GetTipo_Vehiculos()
        {
            return await _context.Tipo_Vehiculos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo_Vehiculo>> GetTipo_Vehiculo(int id)
        {
            var tipo_Vehiculo = await _context.Tipo_Vehiculos.FindAsync(id);
            if (tipo_Vehiculo == null)
            {
                return NotFound();
            }
            return tipo_Vehiculo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo_Vehiculo(int id, Tipo_Vehiculo tipo_Vehiculo)
        {
            if (id != tipo_Vehiculo.Id_Tipo_Vehiculo)
            {
                return BadRequest();
            }
            _context.Entry(tipo_Vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_VehiculoExists(id))
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
        public async Task<ActionResult<Tipo_Vehiculo>> PostCliente(Tipo_Vehiculo tipo_Vehiculo)
        {
            _context.Tipo_Vehiculos.Add(tipo_Vehiculo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTipo_Vehiculo", new { id = tipo_Vehiculo.Id_Tipo_Vehiculo }, tipo_Vehiculo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo_Vehiculo(int id)
        {
            var tipo_Vehiculo = await _context.Tipo_Vehiculos.FindAsync(id);
            if (tipo_Vehiculo == null)
            {
                return NotFound();
            }
            _context.Tipo_Vehiculos.Remove(tipo_Vehiculo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool Tipo_VehiculoExists(int id)
        {
            return _context.Tipo_Vehiculos.Any(e => e.Id_Tipo_Vehiculo == id);
        }
    }
}
