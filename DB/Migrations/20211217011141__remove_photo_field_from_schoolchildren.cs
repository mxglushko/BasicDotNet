using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class _remove_photo_field_from_schoolchildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Schoolchildren");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Schoolchildren",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
