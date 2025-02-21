using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(x => x.Id);

            builder.HasMany(s => s.Items)
              .WithOne(i => i.Sale)
              .HasForeignKey(i => i.Id)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
