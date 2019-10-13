using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<UsuarioDominio> Usuarios { get; set; }

        public DbSet<ProdutoDominio> Produtos { get; set; }

        public DbSet<CategoriaDominio> Categorias { get; set; }
    }
}
