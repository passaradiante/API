using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //Obter Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDominio>>> ObterUsuarios() => await _context.Usuarios.ToListAsync();

        //Buscar por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDominio>> BuscarUsuarioId(int id)
        {
            var validacao = new { transacao = "Reprovada", mensagem = "Usuario não encontrado" };

            var usuarioDominio = await _context.Usuarios.FindAsync(id);
            if (usuarioDominio == null)
                return StatusCode(404, validacao);

            return usuarioDominio;
        }

        //Atualizar dados de um usuário
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, UsuarioDominio usuario)
        {
            var validacao = new { transacao = "Reprovada", mensagem = "Usuario não encontrado" };
            var response = new { transacao = "Aprovada", mensagem = "Usuario atualizado com sucesso" };

            if (!ExisteUsuario(id))
                return StatusCode(404, validacao);

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(200, response);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }
        }

        //Adicionar um novo usuário
        [HttpPost]
        public async Task<ActionResult<UsuarioDominio>> AdicionarUsuario(UsuarioDominio usuario)
        {
            var validacao = new { transacao = "Reprovada", mensagem = "E-mail já cadastrado" };
            var response = new { transacao = "Aprovada", mensagem = "Usuario cadastrado com sucesso" };

            if (ExisteEmailUsuario(usuario))
                return StatusCode(500, validacao);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return StatusCode(200, response);
        }

        //Deletar um usuário
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDominio>> DeletarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        //Verificar se o usuário existe
        private bool ExisteUsuario(int id)
        {
            return _context.Usuarios.Any(e => e.id == id);
        }

        //Verificar se o e-mail do usuário existe
        private bool ExisteEmailUsuario(UsuarioDominio usuario)
        {
            return _context.Usuarios.Any(e => e.email == usuario.email);
        }  
    }
}
