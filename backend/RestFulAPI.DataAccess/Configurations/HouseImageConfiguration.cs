using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations
{
    internal class HouseImageConfiguration : IEntityTypeConfiguration<HouseImage>
    {
        public void Configure(EntityTypeBuilder<HouseImage> builder)
        {
            builder.HasKey(fi => fi.Id);

            builder.Property(fi => fi.HouseId);

            builder.HasOne(fi => fi.House);

            builder.Property(fi => fi.MainImageName);

            builder.Property(fi => fi.BigImageName);

            builder.Property(fi => fi.FirstSmallImageName);

            builder.Property(fi => fi.SecondSmallImageName);
        }
    }
}
