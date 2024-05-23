using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Infrastructure.Contexts
{
    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightSearch> FlightSearches { get; set; }
        public virtual DbSet<HotelSearch> HotelSearches { get; set; }
        public virtual DbSet<RentalSearch> RentalSearches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightSearch>(entity =>
            {
                
                entity.ToTable("FlightSearch");

                entity.HasKey(e => e.Id).HasName("Id");

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.TravelerPrices).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<HotelSearch>(entity =>
            {
                entity.ToTable("HotelSearch");

                entity.HasKey(e => e.Id).HasName("Id");

                entity.Property(e => e.CheckinDate).HasColumnType("datetime");

                entity.Property(e => e.CheckoutDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).IsRequired();

                entity.Property(e => e.ReviewScore).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<RentalSearch>(entity =>
            {
                entity.ToTable("RentalSearch");

                entity.HasKey(e => e.Id).HasName("Id");

                entity.Property(e => e.DropOffDate).HasColumnType("datetime");

                entity.Property(e => e.From).HasMaxLength(450);

                entity.Property(e => e.PickupDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.To).HasMaxLength(450);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
