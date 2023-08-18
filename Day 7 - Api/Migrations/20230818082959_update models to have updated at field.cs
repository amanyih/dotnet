using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day_7___Api.Migrations
{
    /// <inheritdoc />
    public partial class updatemodelstohaveupdatedatfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Posts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Comments",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Posts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Posts",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Comments",
                newName: "Created");
        }
    }
}
