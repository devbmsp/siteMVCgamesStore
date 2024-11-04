using BNC.Models;
using Microsoft.EntityFrameworkCore;

namespace BNC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
            
        }
        public DbSet<HomeModel> Users  { get; set; }
    }
}
