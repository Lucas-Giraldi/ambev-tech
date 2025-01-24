using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.Property(u => u.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.HasOne(p => p.Rating)
                .WithOne(r => r.Product)
                .HasForeignKey<ProductRating>(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
