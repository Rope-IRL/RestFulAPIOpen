using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class LandlordConfiguration : IEntityTypeConfiguration<Landlord>
{
    public void Configure(EntityTypeBuilder<Landlord> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ValueGeneratedOnAdd();
        builder.Property(l => l.Login).HasMaxLength(50);
        builder.Property(l => l.HashedPassword).HasMaxLength(100);
        builder.Property(l => l.Email).HasMaxLength(50);
        builder.HasIndex(l => l.Email).IsUnique();
        builder.HasMany(l => l.Flats)
            .WithOne(f => f.LandLord)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(l => l.Houses)
            .WithOne(f => f.LandLord)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(l => l.Hotels)
            .WithOne(f => f.LandLord)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(l => l.FlatContracts)
            .WithOne(c => c.Landlord)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(l => l.HouseContracts)
            .WithOne(c => c.Landlord)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(l => l.RoomContracts)
            .WithOne(c => c.Landlord)
            .OnDelete(DeleteBehavior.Cascade);
    }
}