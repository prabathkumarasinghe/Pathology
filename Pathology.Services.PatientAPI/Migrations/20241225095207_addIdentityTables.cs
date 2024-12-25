using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathology.Services.PatientAPI.Migrations
{
    /// <inheritdoc />
    public partial class addIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientNumber",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 25, 20, 22, 7, 456, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientNumber",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 25, 20, 22, 7, 456, DateTimeKind.Local).AddTicks(5908));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientNumber",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 9, 1, 23, 28, 485, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientNumber",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 9, 1, 23, 28, 485, DateTimeKind.Local).AddTicks(6329));
        }
    }
}
