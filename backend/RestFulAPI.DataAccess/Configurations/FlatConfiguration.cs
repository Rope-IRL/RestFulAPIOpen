using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class FlatConfiguration : IEntityTypeConfiguration<Flat>
{
    public void Configure(EntityTypeBuilder<Flat> builder)
    {
        // Configure primary key
        builder.HasKey(f => f.Id);

        // Configure properties
        builder.Property(f => f.Id).ValueGeneratedOnAdd();

        builder.Property(f => f.Header)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(f => f.Description)
            .HasMaxLength(1000);

        builder.Property(f => f.AverageMark)
            .HasPrecision(2, 1);

        builder.Property(f => f.City)
            .HasMaxLength(50);

        builder.Property(f => f.Address)
            .HasMaxLength(200);

        builder.Property(f => f.NumberOfRooms);

        builder.Property(f => f.NumberOfFloors);

        builder.Property(f => f.IsBathroomAvailable);

        builder.Property(f => f.IsWiFiAvailable);

        builder.Property(f => f.CostPerDay)
            .HasPrecision(18, 2)
            .HasColumnType("MONEY");

        // Configure relationships

        // One-to-Many: Flat -> Landlord with cascade delete
        builder.HasOne(f => f.LandLord)
            .WithMany(ll => ll.Flats)
            .HasForeignKey(f => f.LlId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Flat -> Contracts with cascade delete
        builder.HasMany(f => f.Contracts)
            .WithOne(c => c.Flat)
            .HasForeignKey(c => c.FlatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}