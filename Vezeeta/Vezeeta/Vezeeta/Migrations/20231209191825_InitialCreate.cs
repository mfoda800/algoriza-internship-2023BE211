using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vezeeta.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscoundType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    discoundCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    discoundType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    discoundPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoundType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SettingStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Specialize = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    SpecializeID = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations",
                        column: x => x.SpecializeID,
                        principalTable: "Specializations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    discoundCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    finalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Prescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Setting_Doctors",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Setting_Patients",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Setting_SettingStatus",
                        column: x => x.Status,
                        principalTable: "SettingStatus",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializeID",
                table: "Doctors",
                column: "SpecializeID");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_DoctorID",
                table: "Setting",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_PatientID",
                table: "Setting",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_Status",
                table: "Setting",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscoundType");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "SettingStatus");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
