using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositorio
{
    public class ProdutoRepositorio
     {
        private readonly DatabaseContext _context;

        public ProdutoRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<Produto> ObterProdutos() => _context.Produtos;

        public bool AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public void AtualizarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Produto ProdutoPorId(int id) => _context.Produtos.Include(i => i.Usuario).SingleOrDefault(x => x.Id == id);

        public void DeletarProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public bool ExisteProduto(int id) => _context.Produtos.Any(e => e.Id == id) ? true : false;

    }

}
