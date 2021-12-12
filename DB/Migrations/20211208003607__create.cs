using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class _create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schoolchildren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassNumber = table.Column<int>(type: "int", nullable: false),
                    StartDateOfClasses = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schoolchildren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolchildrenElectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolchildrenId = table.Column<int>(type: "int", nullable: false),
                    ElectivesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolchildrenElectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolchildrenElectives_Electives_ElectivesId",
                        column: x => x.ElectivesId,
                        principalTable: "Electives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolchildrenElectives_Schoolchildren_SchoolchildrenId",
                        column: x => x.SchoolchildrenId,
                        principalTable: "Schoolchildren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolchildrenElectives_ElectivesId",
                table: "SchoolchildrenElectives",
                column: "ElectivesId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolchildrenElectives_SchoolchildrenId",
                table: "SchoolchildrenElectives",
                column: "SchoolchildrenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolchildrenElectives");

            migrationBuilder.DropTable(
                name: "Electives");

            migrationBuilder.DropTable(
                name: "Schoolchildren");
        }
    }
}
