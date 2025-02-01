using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("userAddress");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User) 
           .WithOne(u => u.UserAddress)
           .HasForeignKey<UserAddress>(p => p.UserId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
