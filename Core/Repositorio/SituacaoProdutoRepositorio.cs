using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositorio
{
    public class SolicitacaoProdutoRepositorio
     {
        private readonly DatabaseContext _context;

        public SolicitacaoProdutoRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<SolicitacaoProduto> ObterSolicitacaoProdutos() => _context.SolicitacaoProduto;

        public SolicitacaoProduto ObterSolicitacaoPorId(int idSolicitacao) => _context.SolicitacaoProduto.Include(i => i.UsuarioAnunciante).Include(i => i.Produto).SingleOrDefault(s => s.Id == idSolicitacao);

        public bool AdicionarSolicitacaoProduto(SolicitacaoProduto situacao)
        {
            _context.SolicitacaoProduto.Add(situacao);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public void AtualizarSolicitacaoProduto(SolicitacaoProduto situacao)
        {
            _context.Entry(situacao).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool DeletarProduto(SolicitacaoProduto situacao)
        {
            _context.SolicitacaoProduto.Remove(situacao);
          return _context.SaveChanges() == 1 ? true : false;
        }

        public bool Lida(int id)
        {
            var situacao = _context.SolicitacaoProduto.SingleOrDefault(x => x.Id == id);
            situacao.Lido = true;
            _context.Update(situacao);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public IList<SolicitacaoProduto> SolicitacoesPorAnunciante(string idAnunciante)
        {
            return _context.SolicitacaoProduto.Include(i => i.Produto)
                                              .Include(i => i.UsuarioSolicitante)
                                              .Include(i => i.UsuarioAnunciante)
                                              .Where(x => x.UsuarioAnunciante.Id == idAnunciante).ToList();
        }

        public IList<SolicitacaoProduto> SolicitacoesPorSolicitante(string idSolicitante)
        {
            return _context.SolicitacaoProduto.Include(i => i.Produto)
                                              .Include(i => i.UsuarioSolicitante)
                                              .Include(i => i.UsuarioAnunciante)
                                              .Include(i => i.Status)
                                              .Where(x => x.UsuarioSolicitante.Id == idSolicitante).ToList();
        }
    }

}
