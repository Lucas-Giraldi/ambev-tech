using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            builder.ToTable("ProductRating");

            builder.HasKey(p => p.Id);

            builder.Property(u => u.Id)
             .HasColumnType("uuid") 
             .ValueGeneratedOnAdd();

            builder.HasOne(p => p.Product)
              .WithOne(r => r.Rating)
              .HasForeignKey<ProductRating>(r => r.ProductId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
