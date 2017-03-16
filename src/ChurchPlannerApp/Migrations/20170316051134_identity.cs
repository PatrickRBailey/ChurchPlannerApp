using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNum",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Profiles",
                nullable: true);
        }
    }
}
