using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations;

public class LesseeAdditionalInfoConfiguration : IEntityTypeConfiguration<LesseeAdditionalInfo>
{
    public void Configure(EntityTypeBuilder<LesseeAdditionalInfo> builder)
    {
        builder.HasKey(li => li.Id);
        builder.Property(li => li.Id).ValueGeneratedOnAdd();
        builder.Property(li => li.Name).HasMaxLength(100);
        builder.Property(li => li.Surname).HasMaxLength(150);
        builder.Property(li => li.Telephone).HasMaxLength(50);
        builder.Property(li => li.PassportId).HasMaxLength(50);
        builder.Property(li => li.AverageMark).HasPrecision(2, 1)
            .HasDefaultValue(0.0m);
        builder.HasOne(li => li.Lessee)
            .WithOne(l => l.AdditionalInfo)
            .OnDelete(DeleteBehavior.Cascade);
    }
}