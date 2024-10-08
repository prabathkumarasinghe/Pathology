using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pathology.Services.PatientAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPatienTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "PatientNumber", "Age", "CreatedDate", "LabNumber", "PatientName", "RefNumber", "Sex", "TestType" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2024, 10, 9, 1, 23, 28, 485, DateTimeKind.Local).AddTicks(6290), 2390, "Nimal", 1212, "male", "FBC" },
                    { 2, 12, new DateTime(2024, 10, 9, 1, 23, 28, 485, DateTimeKind.Local).AddTicks(6329), 412, "Nimala", 1099, "Female", "Suger" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "PatientNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "PatientNumber",
                keyValue: 2);
        }
    }
}
