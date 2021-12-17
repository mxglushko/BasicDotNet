﻿// <auto-generated />
using System;
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB.Migrations
{
    [DbContext(typeof(BasicDotNetDataContext))]
    [Migration("20211217010558__change_types_for_schoolchildren_fields")]
    partial class _change_types_for_schoolchildren_fields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB.Models.ElectiveDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ClassNumber")
                        .HasColumnType("tinyint");

                    b.Property<byte>("CountOfStudents")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Electives");
                });

            modelBuilder.Entity("DB.Models.SchoolchildrenDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Schoolchildren");
                });

            modelBuilder.Entity("DB.Models.SchoolchildrenElectivesDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ElectiveId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolchildrenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ElectiveId");

                    b.HasIndex("SchoolchildrenId");

                    b.ToTable("SchoolchildrenElectives");
                });

            modelBuilder.Entity("DB.Models.SchoolchildrenElectivesDB", b =>
                {
                    b.HasOne("DB.Models.ElectiveDB", "Elective")
                        .WithMany("SchoolchildrenElectives")
                        .HasForeignKey("ElectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.SchoolchildrenDB", "Schoolchildren")
                        .WithMany("SchoolchildrenElectives")
                        .HasForeignKey("SchoolchildrenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Elective");

                    b.Navigation("Schoolchildren");
                });

            modelBuilder.Entity("DB.Models.ElectiveDB", b =>
                {
                    b.Navigation("SchoolchildrenElectives");
                });

            modelBuilder.Entity("DB.Models.SchoolchildrenDB", b =>
                {
                    b.Navigation("SchoolchildrenElectives");
                });
#pragma warning restore 612, 618
        }
    }
}
