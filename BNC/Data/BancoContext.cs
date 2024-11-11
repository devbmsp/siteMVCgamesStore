using BNC.Models;
using Microsoft.EntityFrameworkCore;

namespace BNC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ItensModel> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de chave primária explícita para o modelo ItensModel
            modelBuilder.Entity<ItensModel>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.Id);

            // Especificando nomes de tabelas no banco de dados, caso queira personalizá-los
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity<ItensModel>().ToTable("Itens");
        }
    }
}
