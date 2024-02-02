using DesafioAutoGlass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAutoGlass.Infrastructure.Data.Mappings
{

    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("Bit");

            builder.Property(p => p.ManufacturingDate)
                .HasColumnType("DateTime");
            
            builder.Property(p => p.ExpirationDate)
                .HasColumnType("DateTime");

            builder.ToTable("Produtos");

        }
    }
}
