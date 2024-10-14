using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestFulAPI;

public partial class RealestaterentalContext : DbContext
{
    public RealestaterentalContext()
    {
    }

    public RealestaterentalContext(DbContextOptions<RealestaterentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flat> Flats { get; set; }

    public virtual DbSet<FlatsContract> FlatsContracts { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelsRoom> HotelsRooms { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<HousesContract> HousesContracts { get; set; }

    public virtual DbSet<LandLord> LandLords { get; set; }

    public virtual DbSet<LandLordsAdditionalInfo> LandLordsAdditionalInfos { get; set; }

    public virtual DbSet<Lessee> Lessees { get; set; }

    public virtual DbSet<LesseesAdditionalInfo> LesseesAdditionalInfos { get; set; }

    public virtual DbSet<RoomsContract> RoomsContracts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ConfigurationBuilder builder = new();

        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot configuration = builder.AddUserSecrets<Program>().Build();

        string connectionString = "";
        connectionString = configuration.GetConnectionString("SQLConnection");

        _ = optionsBuilder
            .UseSqlServer(connectionString)
            .Options;
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flat>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PK__Flats__C1D1314A037B5BCD");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");
        });

        modelBuilder.Entity<FlatsContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FlatsCon__3214EC07DD81DD64");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Hid).HasName("PK__Hotels__C750193FFB0EDCD9");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

        });

        modelBuilder.Entity<HotelsRoom>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PK__HotelsRo__CAF055CAC52A9CD5");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Houses__C57059389CC87CA9");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.CostPerDay).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.Llid).HasColumnName("LLid");

        });

        modelBuilder.Entity<HousesContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HousesCo__3214EC078D3C1490");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

        });

        modelBuilder.Entity<LandLord>(entity =>
        {
            entity.HasKey(e => e.Llid).HasName("PK__LandLord__77BE170E87930B01");

            entity.Property(e => e.Llid).HasColumnName("LLid");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<LandLordsAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LandLord__3214EC070805EFB1");

            entity.ToTable("LandLordsAdditionalInfo");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Llid).HasColumnName("LLid");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportId).HasMaxLength(70);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Telephone).HasMaxLength(20);

        });

        modelBuilder.Entity<Lessee>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__Lessees__C6505B39CFD1C6CC");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<LesseesAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LesseesA__3214EC072BB0F616");

            entity.ToTable("LesseesAdditionalInfo");

            entity.Property(e => e.AvgMark).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PassportId).HasMaxLength(70);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Telephone).HasMaxLength(20);

        });

        modelBuilder.Entity<RoomsContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomsCon__3214EC071DBA45A5");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Llid).HasColumnName("LLid");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
