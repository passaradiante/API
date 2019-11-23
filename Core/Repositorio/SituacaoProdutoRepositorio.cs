using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositorio
{
    public class SituacaoProdutoRepositorio
     {
        private readonly DatabaseContext _context;

        public SituacaoProdutoRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<SituacaoProduto> ObterSituacaoProdutos() => _context.SituacaoProduto;

        public bool AdicionarSituacaoProduto(SituacaoProduto situacao)
        {
            _context.SituacaoProduto.Add(situacao);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public void AtualizarSituacaoProduto(SituacaoProduto situacao)
        {
            _context.Entry(situacao).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public SituacaoProduto SituacaoPorId(int id) {

        //  return  _context.SituacaoProduto
        //                                .Include(i => i.Produto)
        //                                .Include(i => i.UsuarioAnunciante)
        //                                .Include(i => i.UsuarioSolicitante)
        //                                .Include
        //                                .SingleOrDefault(x => x.Id == id);

        //}

        public bool DeletarProduto(SituacaoProduto situacao)
        {
            _context.SituacaoProduto.Remove(situacao);
          return _context.SaveChanges() == 1 ? true : false;
        }

    }

}
