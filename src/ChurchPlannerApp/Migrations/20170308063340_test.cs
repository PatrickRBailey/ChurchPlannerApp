using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileInstruments_Profiles_PlayerProfileID",
                table: "ProfileInstruments");

            migrationBuilder.DropIndex(
                name: "IX_ProfileInstruments_PlayerProfileID",
                table: "ProfileInstruments");

            migrationBuilder.DropColumn(
                name: "PlayerProfileID",
                table: "ProfileInstruments");

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "ProfileInstruments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Instruments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInstruments_ProfileID",
                table: "ProfileInstruments",
                column: "ProfileID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileInstruments_Profiles_ProfileID",
                table: "ProfileInstruments",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Profiles_ProfileID",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileInstruments_Profiles_ProfileID",
                table: "ProfileInstruments");

            migrationBuilder.DropIndex(
                name: "IX_ProfileInstruments_ProfileID",
                table: "ProfileInstruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_ProfileID",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "ProfileInstruments");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Instruments");

            migrationBuilder.AddColumn<int>(
                name: "PlayerProfileID",
                table: "ProfileInstruments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInstruments_PlayerProfileID",
                table: "ProfileInstruments",
                column: "PlayerProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileInstruments_Profiles_PlayerProfileID",
                table: "ProfileInstruments",
                column: "PlayerProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
