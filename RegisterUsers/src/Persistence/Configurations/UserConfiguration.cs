using Domain.Entities.Address;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasConversion(
            user => user.Value,
            id => new UserId(id)
        );

        builder.Property(u => u.AddressId).HasConversion(
            addressId => addressId.Value,
            id => new AddressId(id)
        );

        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(1000);

        builder.HasOne(u => u.Address)
            .WithOne()
            .HasForeignKey<User>(u => u.AddressId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(u => u.Email).IsUnique();
    }
}
