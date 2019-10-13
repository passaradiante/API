using System.Collections.Generic;
using WebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly DatabaseContext _context;

        public UsuarioRepositorio(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioDominio> ObterUsuarios()
        {
            return _context.Usuarios;
        }

        public void CadastrarUsuario(UsuarioDominio usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void AtualizarUsuario(UsuarioDominio usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public UsuarioDominio UsuarioPorId(int id)
        {
            var usuarioId = _context.Usuarios.Find(id);
            return usuarioId;
        }

        public void DeletarUsuario(UsuarioDominio usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public bool ExisteUsuario(int id) => _context.Usuarios.Any(e => e.id == id) ? true : false;

        public bool ExisteEmailUsuario(UsuarioDominio usuario) => _context.Usuarios.Any(e => e.email == usuario.email) ? true : false;

    }

}
