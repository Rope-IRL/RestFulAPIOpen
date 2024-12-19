using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Configurations
{
    public class FlatImageConfiguration : IEntityTypeConfiguration<FlatImage>
    {
        public void Configure(EntityTypeBuilder<FlatImage> builder)
        {
            builder.HasKey(fi => fi.Id);

            builder.Property(fi => fi.FlatId);

            builder.HasOne(fi => fi.Flat);

            builder.Property(fi => fi.MainImageName);

            builder.Property(fi => fi.BigImageName);

            builder.Property(fi => fi.FirstSmallImageName);

            builder.Property(fi => fi.SecondSmallImageName);

        }
    }
}
