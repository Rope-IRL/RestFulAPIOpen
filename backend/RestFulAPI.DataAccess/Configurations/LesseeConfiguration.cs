using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class LesseeConfiguration : IEntityTypeConfiguration<Lessee>
{
    public void Configure(EntityTypeBuilder<Lessee> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ValueGeneratedOnAdd();
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(l => l.Login).HasMaxLength(50);
        builder.Property(l => l.HashedPassword).HasMaxLength(100);
        builder.Property(l => l.Email).HasMaxLength(50);
        builder.HasIndex(l => l.Email).IsUnique();
        builder.HasMany(l => l.FlatContracts)
            .WithOne(c => c.Lessee)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(l => l.HouseContracts)
            .WithOne(c => c.Lessee)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(l => l.RoomContracts)
            .WithOne(c => c.Lessee)
            .OnDelete(DeleteBehavior.Cascade);
    }
}