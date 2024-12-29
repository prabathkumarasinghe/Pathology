using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pathology.Services.PatientsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    PatientNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNumber = table.Column<int>(type: "int", nullable: false),
                    LabNumber = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.PatientNumber);
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "PatientNumber", "Age", "CreatedDate", "LabNumber", "PatientName", "RefNumber", "Sex", "TestType" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2024, 12, 28, 2, 38, 50, 779, DateTimeKind.Local).AddTicks(1161), 2390, "Nimal", 1212, "male", "FBC" },
                    { 2, 12, new DateTime(2024, 12, 28, 2, 38, 50, 779, DateTimeKind.Local).AddTicks(5606), 412, "Nimala", 1099, "Female", "Suger" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
