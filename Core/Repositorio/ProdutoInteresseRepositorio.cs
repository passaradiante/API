using System.Collections.Generic;
using WebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositorio
{
    public class ProdutoInteresseRepositorio
    {
        private readonly DatabaseContext _context;

        public ProdutoInteresseRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<ProdutoInteresse> ObterProdutoInteresses() => _context.ProdutoInteresses.Include(i => i.Produto).Include(i => i.UsuarioSolicitante).Include(i => i.UsuarioAnunciante);

        public ProdutoInteresse InteressePorId(int id) => _context.ProdutoInteresses.Include(i => i.Produto).Include(i => i.UsuarioSolicitante).Include(i => i.UsuarioAnunciante).SingleOrDefault(x => x.Id == id);

        public bool AdicionarRelacao(ProdutoInteresse request)
        {
            _context.ProdutoInteresses.Add(request);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public void DeletarRelacao(ProdutoInteresse request)
        {
            _context.ProdutoInteresses.Remove(request);
            _context.SaveChanges();
        }

        public void AtualizarInteresse(ProdutoInteresse request)
        {
            _context.ProdutoInteresses.Update(request);
            _context.SaveChanges();
        }
        

        public IList<ProdutoInteresse> InteressePorAnunciante(string idAnunciante)
        {
            return _context.ProdutoInteresses.Include(i => i.Produto)
                                             .Include(i => i.UsuarioSolicitante)
                                             .Include(i => i.UsuarioAnunciante)
                                             .Where(x => x.UsuarioAnunciante.Id == idAnunciante).ToList();
        }

        public bool Lido(int id)
        {
            var interesse = _context.ProdutoInteresses.SingleOrDefault(x => x.Id == id);
            interesse.Lido = true;
            _context.Update(interesse);
           return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UsuarioJaSolicitou(int idProduto, string idUsuario)
        {
            return _context.ProdutoInteresses.Any(i => i.Produto.Id == idProduto && i.UsuarioSolicitante.Id == idUsuario);
        }
    }

}
