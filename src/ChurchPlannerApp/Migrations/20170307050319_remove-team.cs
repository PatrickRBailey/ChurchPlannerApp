using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class removeteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Services_ServiceID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ServiceID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ServiceID",
                table: "Profiles",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Services_ServiceID",
                table: "Profiles",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
