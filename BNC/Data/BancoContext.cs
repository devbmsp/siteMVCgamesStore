using BNC.Models;
using Microsoft.EntityFrameworkCore;

namespace BNC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
            
        }
        public DbSet<UserModel> Users  { get; set; }
        public DbSet<ItensModel> Itens  { get; set; }
    }
}
