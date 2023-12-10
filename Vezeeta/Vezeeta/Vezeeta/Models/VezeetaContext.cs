using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vezeeta.Models
{
    public partial class VezeetaContext : DbContext
    {
        public VezeetaContext()
        {
        }

        public VezeetaContext(DbContextOptions<VezeetaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiscoundType> DiscoundTypes { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<SettingStatus> SettingStatuses { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-U87T6OC;Database=Vezeeta;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscoundType>(entity =>
            {
                entity.ToTable("DiscoundType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DiscoundCode)
                    .HasMaxLength(50)
                    .HasColumnName("discoundCode");

                entity.Property(e => e.DiscoundPercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("discoundPercent");

                entity.Property(e => e.DiscoundType1)
                    .HasMaxLength(50)
                    .HasColumnName("discoundType");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Phone).HasMaxLength(11);

                entity.Property(e => e.SpecializeId).HasColumnName("SpecializeID");

                entity.HasOne(d => d.Specialize)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecializeId)
                    .HasConstraintName("FK_Doctors_Specializations");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Phone).HasMaxLength(11);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DiscoundCode)
                    .HasMaxLength(50)
                    .HasColumnName("discoundCode");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.FinalPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("finalPrice");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Setting_Doctors");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Setting_Patients");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Setting_SettingStatus");
            });

            modelBuilder.Entity<SettingStatus>(entity =>
            {
                entity.ToTable("SettingStatus");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Specialize).HasMaxLength(120);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
