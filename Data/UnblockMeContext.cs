using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UnblockMe.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe.Data
{
    public partial class UnblockMeContext : IdentityDbContext<AspNetUsers>
    {
        public UnblockMeContext()
        {
        }

        public UnblockMeContext(DbContextOptions<UnblockMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Location> Location { get; set; }


       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Pictures)
                    .HasColumnName("pictures")
                    .HasMaxLength(50);

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.LicensePlate)
                    .HasName("PK_Car_1");

                entity.HasIndex(e => e.LicensePlate)
                    .HasName("IX_Car");

                entity.Property(e => e.LicensePlate)
                    .HasColumnName("license_plate")
                    .HasMaxLength(20);

                entity.Property(e => e.BlockedByLicensePlate)
                    .HasColumnName("blockedBy_license_plate")
                    .HasMaxLength(20);

                entity.Property(e => e.BlockedLicensePlate)
                    .HasColumnName("blocked_license_plate")
                    .HasMaxLength(20);

                entity.Property(e => e.Colour)
                    .HasColumnName("colour")
                    .HasMaxLength(20);

                entity.Property(e => e.Maker)
                    .HasColumnName("maker")
                    .HasMaxLength(20);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(20);

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasColumnName("owner_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_AspNetUsers");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasMaxLength(50);

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
