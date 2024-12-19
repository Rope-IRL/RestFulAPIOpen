using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(r => r.Header).HasMaxLength(200);
        builder.Property(r => r.Description).HasMaxLength(1000);
        builder.Property(r => r.CostPerDay).HasPrecision(18, 2);
        builder.Property(r => r.IsBathroomAvailable);
        builder.Property(r => r.IsWiFiAvailable);
        builder.Property(f => f.AverageMark)
        .HasPrecision(2, 1);
        builder.Property(f => f.NumberOfRooms);
        builder.Property(f => f.NumberOfFloors);
        builder.Property(c => c.CostPerDay).HasPrecision(18, 2).HasColumnType("MONEY");
        builder.HasOne(r => r.Hotel)
            .WithMany(h => h.HotelRooms)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(r => r.HotelId);
        builder.HasMany(r => r.Contracts)
            .WithOne(c => c.Room)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}