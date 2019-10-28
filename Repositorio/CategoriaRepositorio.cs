using System.Collections.Generic;
using WebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositorio
{
    public class CategoriaRepositorio
    {
        private readonly DatabaseContext _context;

        public CategoriaRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<Categoria> ObterCategorias() => _context.Categorias;


        public void AdicionarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarCategoria(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

        public Categoria CategoriaoPorId(int id) => _context.Categorias.Find(id);
 

        public bool ExisteCategoria(int id) => _context.Categorias.Any(e => e.Id == id) ? true : false;

        public bool ExisteCategoria(Categoria categoria) => _context.Categorias.Any(e => e.Nome == categoria.Nome) ? true : false;


    }

}
