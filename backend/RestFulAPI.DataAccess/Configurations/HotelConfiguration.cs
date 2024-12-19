using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id).ValueGeneratedOnAdd();
        builder.Property(h => h.Header)
            .HasMaxLength(200);
        builder.Property(h => h.Header)
            .HasMaxLength(1000);
        builder.Property(h => h.AverageMark).HasPrecision(2, 1);
        builder.Property(h => h.City).HasMaxLength(100);
        builder.Property(h => h.Address).HasMaxLength(200);
        builder.Property(r => r.IsElevatorAvailable);
        builder.Property(r => r.IsRestraintAvailable);
        builder.HasOne(h => h.LandLord)
            .WithMany(ll => ll.Hotels)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(h => h.LlId);

        builder.HasMany(h => h.HotelRooms)
            .WithOne(hr => hr.Hotel)
            .OnDelete(DeleteBehavior.Cascade);
    }
}