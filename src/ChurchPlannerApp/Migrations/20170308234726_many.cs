using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstrumentID",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_InstrumentID",
                table: "Profiles",
                column: "InstrumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Instruments_InstrumentID",
                table: "Profiles",
                column: "InstrumentID",
                principalTable: "Instruments",
                principalColumn: "InstrumentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Instruments_InstrumentID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_InstrumentID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "InstrumentID",
                table: "Profiles");
        }
    }
}
