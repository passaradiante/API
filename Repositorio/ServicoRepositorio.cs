using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositorio
{
    public class ServicoRepositorio
     {
        private readonly DatabaseContext _context;

        public ServicoRepositorio(DatabaseContext context) => _context = context;

        public IEnumerable<Servico> ObterServicos() => _context.Servicos;

    }

}
