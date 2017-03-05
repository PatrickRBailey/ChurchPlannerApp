using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchPlannerApp.Migrations
{
    public partial class propChane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Profiles_ProfileID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Services_ServiceID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ProfileID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ServiceID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "ProfileRProfileID",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRServiceID",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProfileRProfileID",
                table: "Requests",
                column: "ProfileRProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceRServiceID",
                table: "Requests",
                column: "ServiceRServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Profiles_ProfileRProfileID",
                table: "Requests",
                column: "ProfileRProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Services_ServiceRServiceID",
                table: "Requests",
                column: "ServiceRServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Profiles_ProfileRProfileID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Services_ServiceRServiceID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ProfileRProfileID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ServiceRServiceID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProfileRProfileID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ServiceRServiceID",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProfileID",
                table: "Requests",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceID",
                table: "Requests",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Profiles_ProfileID",
                table: "Requests",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Services_ServiceID",
                table: "Requests",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
