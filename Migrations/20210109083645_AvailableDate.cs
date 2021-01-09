using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naros_Ana_Maria_AdoptAPet.Migrations
{
    public partial class AvailableDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableDate",
                table: "Pet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableDate",
                table: "Pet");
        }
    }
}
