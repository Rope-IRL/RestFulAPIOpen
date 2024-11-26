using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class HouseContractConfiguration : IEntityTypeConfiguration<HouseContract>
{
    public void Configure(EntityTypeBuilder<HouseContract> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.StartDate);
        builder.Property(c => c.EndDate);
        builder.Property(c => c.Cost).HasPrecision(18, 2).HasColumnType("MONEY");
        builder.HasOne(c => c.House)
            .WithMany(f => f.Contracts)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(c => c.HouseId);
        builder.HasOne(c => c.Landlord)
            .WithMany(ll => ll.HouseContracts)
            .HasForeignKey(f => f.LandlordId)
            .OnDelete(DeleteBehavior.Restrict);;
        builder.HasOne(c => c.Lessee)
            .WithMany(l => l.HouseContracts)
            .HasForeignKey(f => f.LesseeId)
            .OnDelete(DeleteBehavior.Restrict);;
    }
    
}