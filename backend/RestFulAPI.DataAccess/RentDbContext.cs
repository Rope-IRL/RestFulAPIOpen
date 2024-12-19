using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestFulAPI.Core.Models;
using RestFulAPI.DataAccess.Configurations;

namespace RestFulAPI.DataAccess;

public class RentDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Flat> Flats { get; set; }

    public DbSet<FlatImage> FlatImages { get; set; }
    
    public DbSet<FlatContract> FlatContracts { get; set; }
    
    public DbSet<House> Houses { get; set; }

    public DbSet<HouseImage> HouseImages { get; set; }
    
    public DbSet<HouseContract> HouseContracts { get; set; }
    
    public DbSet<Hotel> Hotels { get; set; }
    
    public DbSet<Room> Rooms { get; set; }

    public DbSet<RoomImage> RoomImages { get; set; }
        
    public DbSet<RoomContract> RoomContracts { get; set; }
    
    public DbSet<Landlord> Landlords { get; set; }
    
    public DbSet<LandlordAdditionalInfo> LandlordAdditionalInfos { get; set; }
    
    public DbSet<Lessee> Lessees { get; set; }
    
    public DbSet<LesseeAdditionalInfo> LesseeAdditionalInfos { get; set; }

    protected override  void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LesseeConfiguration());
        modelBuilder.ApplyConfiguration(new LesseeAdditionalInfoConfiguration());
        modelBuilder.ApplyConfiguration(new LandlordConfiguration());
        modelBuilder.ApplyConfiguration(new LandlordAdditionalInfoConfiguration());
        modelBuilder.ApplyConfiguration(new FlatConfiguration());
        modelBuilder.ApplyConfiguration(new FlatContractConfiguration());
        modelBuilder.ApplyConfiguration(new HouseConfiguration());
        modelBuilder.ApplyConfiguration(new HouseContractConfiguration());
        modelBuilder.ApplyConfiguration(new HotelConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomContractConfiguration());
        modelBuilder.ApplyConfiguration(new FlatImageConfiguration());
        modelBuilder.ApplyConfiguration(new HouseImageConfiguration());
        modelBuilder.ApplyConfiguration(new RoomImageConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MsSqlConnection"));
    }
}