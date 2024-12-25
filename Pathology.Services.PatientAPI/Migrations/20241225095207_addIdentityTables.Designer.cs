﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pathology.Services.PatientAPI.Data;

#nullable disable

namespace Pathology.Services.PatientAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241225095207_addIdentityTables")]
    partial class addIdentityTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pathology.Services.PatientAPI.Models.Patient", b =>
                {
                    b.Property<int>("PatientNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientNumber"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LabNumber")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RefNumber")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientNumber");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            PatientNumber = 1,
                            Age = 10,
                            CreatedDate = new DateTime(2024, 12, 25, 20, 22, 7, 456, DateTimeKind.Local).AddTicks(5837),
                            LabNumber = 2390,
                            PatientName = "Nimal",
                            RefNumber = 1212,
                            Sex = "male",
                            TestType = "FBC"
                        },
                        new
                        {
                            PatientNumber = 2,
                            Age = 12,
                            CreatedDate = new DateTime(2024, 12, 25, 20, 22, 7, 456, DateTimeKind.Local).AddTicks(5908),
                            LabNumber = 412,
                            PatientName = "Nimala",
                            RefNumber = 1099,
                            Sex = "Female",
                            TestType = "Suger"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
