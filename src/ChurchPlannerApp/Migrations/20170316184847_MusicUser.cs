using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChurchPlannerApp.Migrations
{
    public partial class MusicUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicUser",
                columns: table => new
                {
                    MusicUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicUser", x => x.MusicUserID);
                });

            migrationBuilder.AddColumn<int>(
                name: "UserMusicUserID",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserMusicUserID",
                table: "Profiles",
                column: "UserMusicUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_MusicUser_UserMusicUserID",
                table: "Profiles",
                column: "UserMusicUserID",
                principalTable: "MusicUser",
                principalColumn: "MusicUserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_MusicUser_UserMusicUserID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserMusicUserID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserMusicUserID",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "MusicUser");
        }
    }
}
