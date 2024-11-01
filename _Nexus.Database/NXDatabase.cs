using _Nexus.Models;
using Microsoft.EntityFrameworkCore;

namespace _Nexus.Database
{
    public class NXContext : DbContext

    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }

        public NXContext(DbContextOptions<NXContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
