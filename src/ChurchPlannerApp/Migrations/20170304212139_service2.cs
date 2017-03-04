using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChurchPlannerApp.Migrations
{
    public partial class service2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PracticeDate = table.Column<DateTime>(nullable: false),
                    ServiceDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
