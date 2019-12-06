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

        public Produto ProdutoPorId(int id) =>_context.Produtos.Include(i => i.Usuario).SingleOrDefault(x => x.Id == id);

        public IEnumerable<Produto> ProdutoPorUsuario(string idUsuario) => _context.Produtos.Include(i => i.Usuario).Include(i => i.Categoria).Where(w => w.Usuario.Id == idUsuario);

        public void DeletarProduto(Produto produto)
        {
            if (_context.ProdutoInteresses.Any(a => a.Produto.Id == produto.Id))
                _context.ProdutoInteresses.Remove(_context.ProdutoInteresses.SingleOrDefault(s => s.Produto.Id == produto.Id));

            if (_context.SolicitacaoProduto.Any(a => a.Produto.Id == produto.Id))
                _context.SolicitacaoProduto.Remove(_context.SolicitacaoProduto.SingleOrDefault(s => s.Produto.Id == produto.Id));

            
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public bool ExisteProduto(int id) => _context.Produtos.Any(e => e.Id == id) ? true : false;

        public bool VerificarSeEhProdutoDoAnunciante(string idUsuario, int idProduto)
        {
            return _context.Produtos.Any(i => i.Id == idProduto && i.Usuario.Id == idUsuario) ? true: false;
        }

    }

}
