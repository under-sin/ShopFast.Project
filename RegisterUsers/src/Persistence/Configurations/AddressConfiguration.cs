using Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address> {
    public void Configure(EntityTypeBuilder<Address> builder) {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            address => address.Value,
            id => new AddressId(id)
        );

        builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(9);
        builder.Property(a => a.State).IsRequired().HasMaxLength(20);
        builder.Property(a => a.City).IsRequired().HasMaxLength(35);
        builder.Property(a => a.Street).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Neighborhood).IsRequired().HasMaxLength(35);
        builder.Property(a => a.Uf).IsRequired().HasMaxLength(2);
        builder.Property(a => a.Number).IsRequired();
        builder.Property(a => a.Complement).HasMaxLength(50);
        builder.Property(a => a.Region).IsRequired().HasMaxLength(20);
    }
}
