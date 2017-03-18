using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Comment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FromMusicUserID",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_FromMusicUserID",
                table: "Comment",
                column: "FromMusicUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_MusicUser_FromMusicUserID",
                table: "Comment",
                column: "FromMusicUserID",
                principalTable: "MusicUser",
                principalColumn: "MusicUserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_MusicUser_FromMusicUserID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_FromMusicUserID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "FromMusicUserID",
                table: "Comment");
        }
    }
}
