using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class Instrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_Profiles_ProfileID",
                table: "Instrument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruments",
                table: "Instrument",
                column: "InstrumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Profiles_ProfileID",
                table: "Instrument",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Instrument_ProfileID",
                table: "Instrument",
                newName: "IX_Instruments_ProfileID");

            migrationBuilder.RenameTable(
                name: "Instrument",
                newName: "Instruments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Profiles_ProfileID",
                table: "Instruments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrument",
                table: "Instruments",
                column: "InstrumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_Profiles_ProfileID",
                table: "Instruments",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Instruments_ProfileID",
                table: "Instruments",
                newName: "IX_Instrument_ProfileID");

            migrationBuilder.RenameTable(
                name: "Instruments",
                newName: "Instrument");
        }
    }
}
