using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class forum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_MusicUser_FromMusicUserID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MusicUser_FromMusicUserID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromMusicUserID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Comment_FromMusicUserID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "FromMusicUserID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromMusicUserID",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "FromProfileID",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromProfileID",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromProfileID",
                table: "Messages",
                column: "FromProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_FromProfileID",
                table: "Comment",
                column: "FromProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Profiles_FromProfileID",
                table: "Comment",
                column: "FromProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_FromProfileID",
                table: "Messages",
                column: "FromProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Profiles_FromProfileID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_FromProfileID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromProfileID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Comment_FromProfileID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "FromProfileID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromProfileID",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "FromMusicUserID",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromMusicUserID",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromMusicUserID",
                table: "Messages",
                column: "FromMusicUserID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MusicUser_FromMusicUserID",
                table: "Messages",
                column: "FromMusicUserID",
                principalTable: "MusicUser",
                principalColumn: "MusicUserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
