using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class _add_few_filds_for_all_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolchildrenElectives_Electives_ElectivesId",
                table: "SchoolchildrenElectives");

            migrationBuilder.RenameColumn(
                name: "ElectivesId",
                table: "SchoolchildrenElectives",
                newName: "ElectiveId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolchildrenElectives_ElectivesId",
                table: "SchoolchildrenElectives",
                newName: "IX_SchoolchildrenElectives_ElectiveId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schoolchildren",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Schoolchildren",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Schoolchildren",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Schoolchildren",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Schoolchildren",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Electives",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte>(
                name: "CountOfStudents",
                table: "Electives",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Electives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Electives",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Electives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Electives",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolchildrenElectives_Electives_ElectiveId",
                table: "SchoolchildrenElectives",
                column: "ElectiveId",
                principalTable: "Electives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolchildrenElectives_Electives_ElectiveId",
                table: "SchoolchildrenElectives");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Schoolchildren");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Schoolchildren");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Schoolchildren");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Schoolchildren");

            migrationBuilder.DropColumn(
                name: "CountOfStudents",
                table: "Electives");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Electives");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Electives");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Electives");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Electives");

            migrationBuilder.RenameColumn(
                name: "ElectiveId",
                table: "SchoolchildrenElectives",
                newName: "ElectivesId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolchildrenElectives_ElectiveId",
                table: "SchoolchildrenElectives",
                newName: "IX_SchoolchildrenElectives_ElectivesId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schoolchildren",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Electives",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolchildrenElectives_Electives_ElectivesId",
                table: "SchoolchildrenElectives",
                column: "ElectivesId",
                principalTable: "Electives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
