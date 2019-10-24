using System.Collections.Generic;
using WebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositorio
{
    public class UsuarioRepositorio
    {
        //private readonly DatabaseContext _context;

        //public UsuarioRepositorio(DatabaseContext context)
        //{
        //    _context = context;
        //}

        //public IEnumerable<Usuario> ObterUsuarios()
        //{
        //    return _context.Usuarios;
        //}

        //public void CadastrarUsuario(Usuario usuario)
        //{
        //    _context.Usuarios.Add(usuario);
        //    _context.SaveChanges();
        //}

        //public void AtualizarUsuario(Usuario usuario)
        //{
        //    _context.Entry(usuario).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

        //public Usuario UsuarioPorId(int id)
        //{
        //    var usuarioId = _context.Usuarios.Find(id);
        //    return usuarioId;
        //}

        //public void DeletarUsuario(Usuario usuario)
        //{
        //    _context.Usuarios.Remove(usuario);
        //    _context.SaveChanges();
        //}

        //public bool ExisteUsuario(int id) => _context.Usuarios.Any(e => e.Id == id) ? true : false;

        //public bool ExisteEmailUsuario(Usuario usuario) => _context.Usuarios.Any(e => e.Email == usuario.Email) ? true : false;

    }

}
