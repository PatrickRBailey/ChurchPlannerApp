using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class testagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileInstruments_Instruments_InstrumentID",
                table: "ProfileInstruments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileInstruments_Profiles_ProfileID",
                table: "ProfileInstruments");

            migrationBuilder.DropIndex(
                name: "IX_ProfileInstruments_InstrumentID",
                table: "ProfileInstruments");

            migrationBuilder.DropIndex(
                name: "IX_ProfileInstruments_ProfileID",
                table: "ProfileInstruments");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileID",
                table: "ProfileInstruments",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentID",
                table: "ProfileInstruments",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProfileID",
                table: "ProfileInstruments",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentID",
                table: "ProfileInstruments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInstruments_InstrumentID",
                table: "ProfileInstruments",
                column: "InstrumentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInstruments_ProfileID",
                table: "ProfileInstruments",
                column: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileInstruments_Instruments_InstrumentID",
                table: "ProfileInstruments",
                column: "InstrumentID",
                principalTable: "Instruments",
                principalColumn: "InstrumentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileInstruments_Profiles_ProfileID",
                table: "ProfileInstruments",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
