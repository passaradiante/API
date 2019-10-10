using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext _context;

        public UsuarioController(
            UsuarioContext context
            )
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDominio>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDominio>> GetUsuario(int id)
        {
            var usuarioDominio = await _context.Usuarios.FindAsync(id);

            if (usuarioDominio == null)
            {
                return NotFound();
            }

            return usuarioDominio;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioDominio usuarioDominio)
        {
            if (id != usuarioDominio.id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioDominio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioDominio>> PostUsuario(UsuarioDominio usuarioDominio)
        {
            _context.Usuarios.Add(usuarioDominio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioDominio", new { id = usuarioDominio.id }, usuarioDominio);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDominio>> DeleteUsuario(int id)
        {
            var usuarioDominio = await _context.Usuarios.FindAsync(id);
            if (usuarioDominio == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarioDominio);
            await _context.SaveChangesAsync();

            return usuarioDominio;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.id == id);
        }
    }
}
