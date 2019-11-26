using System.Collections.Generic;
using WebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositorio
{
    public class SolicitacaoStatusRepositorio
    {
        private readonly DatabaseContext _context;

        public SolicitacaoStatusRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<SolicitacaoStatus> ObterCategorias() => _context.SolicitacaoStatus;


        public void AdicionarSolicitacaoStatus(SolicitacaoStatus request)
        {
            _context.SolicitacaoStatus.Add(request);
            _context.SaveChanges();
        }

        public void AtualizarSolicitacaoStatus(SolicitacaoStatus request)
        {
            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarSolicitacaoStatus(SolicitacaoStatus request)
        {
            _context.SolicitacaoStatus.Remove(request);
            _context.SaveChanges();
        }

        public SolicitacaoStatus StatusPorId(int id) => _context.SolicitacaoStatus.Find(id);
 

        public bool ExisteSolicitacaoStatus(int id) => _context.SolicitacaoStatus.Any(e => e.Id == id) ? true : false;

        public bool ExisteSolicitacaoStatus(SolicitacaoStatus request) => _context.SolicitacaoStatus.Any(e => e.Nome == request.Nome) ? true : false;


    }

}
