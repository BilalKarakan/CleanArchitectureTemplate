using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTemplate.Persistance.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasColumnName(nameof(Product.Name)).HasColumnType("nvarchar(200)").IsRequired();
        builder.Property(p => p.Quantity).HasColumnName(nameof(Product.Quantity)).HasColumnType("int").IsRequired();
        builder.Property(p => p.Price).HasColumnName(nameof(Product.Price)).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(p => p.Description).HasColumnName(nameof(Product.Description)).HasColumnType("nvarchar(500)").IsRequired();
        builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}
