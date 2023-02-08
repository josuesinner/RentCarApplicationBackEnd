using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApplication.DB;
using RentCarApplication.DTOs;

namespace RentCarApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DB_Context _context;

        public ClienteController (DB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            ValidarCedula validarCedula = new ValidarCedula();
            if (id != cliente.Id_Cliente)
            {
                return BadRequest();
            }
            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                if (validarCedula.IsValidIdNumber(cliente.Cedula))
                {
                    validarCedula.IsValidIdNumber(cliente.Cedula);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }

                    
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            ValidarCedula validarCedula = new ValidarCedula();

            try
            {
                if (validarCedula.IsValidIdNumber(cliente.Cedula))
                {
                    _context.Clientes.Add(cliente);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return CreatedAtAction("GetCliente", new { id = cliente.Id_Cliente }, cliente);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCLiente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e=>e.Id_Cliente == id);
        }

    }
}
