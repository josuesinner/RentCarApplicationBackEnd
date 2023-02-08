using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly DB_Context _context;

        public EmpleadoController(DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return empleado;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            ValidarCedula validarCedula = new ValidarCedula();

            if (id != empleado.Id_Empleado)
            {
                return BadRequest();
            }
            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                if (validarCedula.IsValidIdNumber(empleado.Cedula))
                {
                    validarCedula.IsValidIdNumber(empleado.Cedula);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }
                    
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            ValidarCedula validarCedula = new ValidarCedula();

            try
            {
                if (validarCedula.IsValidIdNumber(empleado.Cedula))
                {
                    _context.Empleados.Add(empleado);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {

            }
            
            return CreatedAtAction("GetEmpleado", new { id = empleado.Id_Empleado }, empleado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id_Empleado == id);
        }
    }
}
