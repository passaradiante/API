using System.Collections.Generic;
using WebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositorio
{
    public class SituacaoStatusRepositorio
    {
        private readonly DatabaseContext _context;

        public SituacaoStatusRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<SituacaoStatus> ObterCategorias() => _context.SituacaoStatus;


        public void AdicionarSituacaoStatus(SituacaoStatus request)
        {
            _context.SituacaoStatus.Add(request);
            _context.SaveChanges();
        }

        public void AtualizarSituacaoStatus(SituacaoStatus request)
        {
            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarSituacaoStatus(SituacaoStatus request)
        {
            _context.SituacaoStatus.Remove(request);
            _context.SaveChanges();
        }

        public SituacaoStatus StatusPorId(int id) => _context.SituacaoStatus.Find(id);
 

        public bool ExisteSituacaoStatus(int id) => _context.SituacaoStatus.Any(e => e.Id == id) ? true : false;

        public bool ExisteSituacaoStatus(SituacaoStatus request) => _context.SituacaoStatus.Any(e => e.Nome == request.Nome) ? true : false;


    }

}
