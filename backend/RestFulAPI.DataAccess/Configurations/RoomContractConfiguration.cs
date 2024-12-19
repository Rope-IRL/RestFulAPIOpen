using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class RoomContractConfiguration : IEntityTypeConfiguration<RoomContract>
{
    public void Configure(EntityTypeBuilder<RoomContract> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.StartDate);
        builder.Property(c => c.EndDate);
        builder.Property(c => c.Cost).HasPrecision(18, 2).HasColumnType("MONEY");
        builder.HasOne(c => c.Room)
            .WithMany(f => f.Contracts)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(c => c.RoomId);
        builder.HasOne(c => c.Landlord)
            .WithMany(ll => ll.RoomContracts)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(c => c.Lessee)
            .WithMany(l => l.RoomContracts)
            .OnDelete(DeleteBehavior.Restrict);
    }
}