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
    public  class UnblockMeContext : IdentityDbContext
    {
        public UnblockMeContext()
        {
        }

        public UnblockMeContext(DbContextOptions<UnblockMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<User> User { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-5KHRI9M\\SQLEXPRESS;Database=UnblockMe;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Car>(entity =>
//            {
//                entity.HasKey(e => e.LicensePlate)
//                    .HasName("PK_Car_1");

//                entity.HasIndex(e => e.LicensePlate)
//                    .HasName("IX_Car");

//                entity.HasOne(d => d.Owner)
//                    .WithMany(p => p.Car)
//                    .HasForeignKey(d => d.OwnerId)
//                    .HasConstraintName("FK_Car_User");
//            });

//            modelBuilder.Entity<Location>(entity =>
//            {
//                entity.Property(e => e.Id).ValueGeneratedNever();
//            });

//            modelBuilder.Entity<User>(entity =>
//            {
//                entity.Property(e => e.Id).ValueGeneratedNever();
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
