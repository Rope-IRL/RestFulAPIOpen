using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class FlatContractConfiguration : IEntityTypeConfiguration<FlatContract>
{
    public void Configure(EntityTypeBuilder<FlatContract> builder)
    {
        // Configure primary key
        builder.HasKey(c => c.Id);

        // Configure properties
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.StartDate).IsRequired();
        builder.Property(c => c.EndDate).IsRequired();
        builder.Property(c => c.Cost)
            .HasPrecision(18, 2)
            .HasColumnType("MONEY");
        
        builder.HasOne(c => c.Flat)
            .WithMany(f => f.Contracts)
            .HasForeignKey(c => c.FlatId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if Flat is deleted

        // Landlord -> FlatContract
        builder.HasOne(c => c.Landlord)
            .WithMany(ll => ll.FlatContracts)
            .HasForeignKey(c => c.LandlordId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Landlord if contract exists

        // Lessee -> FlatContract
        builder.HasOne(c => c.Lessee)
            .WithMany(l => l.FlatContracts)
            .HasForeignKey(c => c.LesseeId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Lessee if contract exists
    }
}
