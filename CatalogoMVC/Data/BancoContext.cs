using CatalogoMVC.Data.Map;
using CatalogoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
            
        }
        public DbSet<UsuarioModel> Users  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
