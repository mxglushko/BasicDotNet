using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class _update_elective_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Electives");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Electives");

            migrationBuilder.AddColumn<byte>(
                name: "ClassNumber",
                table: "Electives",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "Electives");

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Electives",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Electives",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
