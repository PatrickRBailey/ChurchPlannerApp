using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class noInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Profiles_ProfileID",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_ProfileID",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Instruments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Instruments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_ProfileID",
                table: "Instruments",
                column: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Profiles_ProfileID",
                table: "Instruments",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
