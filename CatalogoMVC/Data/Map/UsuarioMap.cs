using CatalogoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoMVC.Data.Map 
{ 
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>

    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)

        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Zip).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(150);

        }
    }
}