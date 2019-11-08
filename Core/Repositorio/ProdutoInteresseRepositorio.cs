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

        public IEnumerable<ProdutoInteresse> ObterProdutoInteresses() => _context.ProdutoInteresses;


        public bool AdicionarRelacao(ProdutoInteresse request)
        {
            _context.ProdutoInteresses.Add(request);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public void DeletarRelacaoa(ProdutoInteresse request)
        {
            _context.ProdutoInteresses.Remove(request);
            _context.SaveChanges();
        }

        //public Categoria InteressePorId(int id) => _context.ProdutoInteresses.Find();
 
    }

}
