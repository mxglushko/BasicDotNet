// <auto-generated />
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB.Migrations
{
    [DbContext(typeof(BasicDotNetDataContext))]
    [Migration("20211208015055__hide_StartDateOfClasses")]
    partial class _hide_StartDateOfClasses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB.Models.ElectivesDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schoolchildren");
                });

            modelBuilder.Entity("DB.Models.SchoolchildrenElectivesDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ElectivesId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolchildrenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ElectivesId");

                    b.HasIndex("SchoolchildrenId");

                    b.ToTable("SchoolchildrenElectives");
                });

            modelBuilder.Entity("DB.Models.SchoolchildrenElectivesDB", b =>
                {
                    b.HasOne("DB.Models.ElectivesDB", "Electives")
                        .WithMany()
                        .HasForeignKey("ElectivesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.SchoolchildrenDB", "Schoolchildren")
                        .WithMany()
                        .HasForeignKey("SchoolchildrenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Electives");

                    b.Navigation("Schoolchildren");
                });
#pragma warning restore 612, 618
        }
    }
}
