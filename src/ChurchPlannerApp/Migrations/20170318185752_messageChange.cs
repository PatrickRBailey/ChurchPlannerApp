using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChurchPlannerApp.Migrations
{
    public partial class messageChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_FromProfileID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromProfileID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromProfileID",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: false),
                    MessageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comment_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "FromMusicUserID",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromMusicUserID",
                table: "Messages",
                column: "FromMusicUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MessageID",
                table: "Comment",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MusicUser_FromMusicUserID",
                table: "Messages",
                column: "FromMusicUserID",
                principalTable: "MusicUser",
                principalColumn: "MusicUserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MusicUser_FromMusicUserID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromMusicUserID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromMusicUserID",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "FromProfileID",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromProfileID",
                table: "Messages",
                column: "FromProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_FromProfileID",
                table: "Messages",
                column: "FromProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
