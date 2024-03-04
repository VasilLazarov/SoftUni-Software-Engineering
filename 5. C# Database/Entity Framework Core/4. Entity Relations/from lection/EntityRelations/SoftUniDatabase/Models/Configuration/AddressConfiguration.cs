using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace SoftUniDatabase_ScaffoldedFromPreviousLection.Models.Configuration
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasOne(d => d.Town)
                .WithMany(p => p.Addresses)
                .HasConstraintName("FK_Addresses_Towns");
        }
    }
}
