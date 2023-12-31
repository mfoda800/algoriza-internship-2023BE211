﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vezeeta.Models;

#nullable disable

namespace Vezeeta.Migrations
{
    [DbContext(typeof(VezeetaContext))]
    partial class VezeetaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vezeeta.Models.DiscoundType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("DiscoundCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("discoundCode");

                    b.Property<decimal?>("DiscoundPercent")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("discoundPercent");

                    b.Property<string>("DiscoundType1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("discoundType");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DiscoundType", (string)null);
                });

            modelBuilder.Entity("Vezeeta.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("SpecializeId")
                        .HasColumnType("int")
                        .HasColumnName("SpecializeID");

                    b.HasKey("Id");

                    b.HasIndex("SpecializeId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Vezeeta.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstName");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Vezeeta.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("DiscoundCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("discoundCode");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("DoctorID");

                    b.Property<decimal?>("FinalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("finalPrice");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("PatientID");

                    b.Property<string>("Prescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("Status");

                    b.ToTable("Setting", (string)null);
                });

            modelBuilder.Entity("Vezeeta.Models.SettingStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SettingStatus", (string)null);
                });

            modelBuilder.Entity("Vezeeta.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Specialize")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Vezeeta.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("isAdmin");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vezeeta.Models.Doctor", b =>
                {
                    b.HasOne("Vezeeta.Models.Specialization", "Specialize")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializeId")
                        .HasConstraintName("FK_Doctors_Specializations");

                    b.Navigation("Specialize");
                });

            modelBuilder.Entity("Vezeeta.Models.Setting", b =>
                {
                    b.HasOne("Vezeeta.Models.Doctor", "Doctor")
                        .WithMany("Settings")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Setting_Doctors");

                    b.HasOne("Vezeeta.Models.Patient", "Patient")
                        .WithMany("Settings")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_Setting_Patients");

                    b.HasOne("Vezeeta.Models.SettingStatus", "StatusNavigation")
                        .WithMany("Settings")
                        .HasForeignKey("Status")
                        .HasConstraintName("FK_Setting_SettingStatus");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("StatusNavigation");
                });

            modelBuilder.Entity("Vezeeta.Models.Doctor", b =>
                {
                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Vezeeta.Models.Patient", b =>
                {
                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Vezeeta.Models.SettingStatus", b =>
                {
                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Vezeeta.Models.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
