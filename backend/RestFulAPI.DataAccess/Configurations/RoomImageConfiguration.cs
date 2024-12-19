using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations
{
    internal class RoomImageConfiguration : IEntityTypeConfiguration<RoomImage>
    {
        public void Configure(EntityTypeBuilder<RoomImage> builder)
        {
            builder.HasKey(fi => fi.Id);

            builder.Property(fi => fi.RoomId);

            builder.HasOne(fi => fi.Room);

            builder.Property(fi => fi.MainImageName);

            builder.Property(fi => fi.BigImageName);

            builder.Property(fi => fi.FirstSmallImageName);

            builder.Property(fi => fi.SecondSmallImageName);
        }
    }
}
