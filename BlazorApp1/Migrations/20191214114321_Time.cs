using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.Migrations
{
    public partial class Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "Jobs");

            migrationBuilder.AddColumn<long>(
                name: "DurationTicks",
                table: "Jobs",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationTicks",
                table: "Jobs");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EstimatedTime",
                table: "Jobs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
