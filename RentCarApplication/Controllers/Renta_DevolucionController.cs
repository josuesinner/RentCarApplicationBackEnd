using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Renta_DevolucionController : ControllerBase
    {
        private readonly DB_Context _context;

        public Renta_DevolucionController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Renta_Devolucion>>> GetRenta_Devoluciones()
        {
            return await _context.Renta_Devolucions.Include(x=>x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Renta_Devolucion>> GetRenta_Devolucion(int id)
        {
            var renta_Devolucion = await _context.Renta_Devolucions.FindAsync(id);
            if (renta_Devolucion == null)
            {
                return NotFound();
            }
            return renta_Devolucion;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRenta_Devolucion(int id, Renta_Devolucion renta_Devolucion)
        {
            if (id != renta_Devolucion.No_Renta)
            {
                return BadRequest();
            }
            _context.Entry(renta_Devolucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Renta_DevolucionExists(id))
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
        public async Task<ActionResult<Renta_Devolucion>> PostRenta_Devoluciones(Renta_Devolucion renta_Devolucion)
        {
            var insp = VehicleIsInspected((int)renta_Devolucion.VehiculoId, (int)renta_Devolucion.ClienteId);

            if (insp == false)
            {
                return BadRequest();
            }
            else
            {
                _context.Renta_Devolucions.Add(renta_Devolucion);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetRenta_Devolucion", new { id = renta_Devolucion.ClienteId }, renta_Devolucion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRenta_Devolucion(int id)
        {
            var renta_Devolucion = await _context.Renta_Devolucions.FindAsync(id);
            if (renta_Devolucion == null)
            {
                return NotFound();
            }
            _context.Renta_Devolucions.Remove(renta_Devolucion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool Renta_DevolucionExists(int id)
        {
            return _context.Renta_Devolucions.Any(e => e.ClienteId == id);
        }

        private bool VehicleIsInspected(int idVehicle, int idClient)
        {
            var exists = _context.Inspeccions
                            .FirstOrDefault(x => x.VehiculoId == idVehicle && x.ClienteId == idClient);
            return exists != null;
        }
    }
}
