using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChurchPlannerApp.Migrations
{
    public partial class manySetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Profiles_ProfileRProfileID",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Services_ServiceRServiceID",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ProfileRProfileID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ServiceRServiceID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ServiceRequestID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProfileRProfileID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ServiceRServiceID",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Services",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Profiles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceRequest",
                table: "Requests",
                columns: new[] { "ServiceID", "ProfileID" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_ProfileID",
                table: "Requests",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_ServiceID",
                table: "Requests",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Profiles_ProfileID",
                table: "Requests",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_Services_ServiceID",
                table: "Requests",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "ServiceRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Profiles_ProfileID",
                table: "ServiceRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_Services_ServiceID",
                table: "ServiceRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceRequest",
                table: "ServiceRequest");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequest_ProfileID",
                table: "ServiceRequest");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequest_ServiceID",
                table: "ServiceRequest");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "ServiceRequest");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "ServiceRequest");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ServiceRequestID",
                table: "ServiceRequest",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProfileRProfileID",
                table: "ServiceRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRServiceID",
                table: "ServiceRequest",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "ServiceRequest",
                column: "ServiceRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProfileRProfileID",
                table: "ServiceRequest",
                column: "ProfileRProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceRServiceID",
                table: "ServiceRequest",
                column: "ServiceRServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Profiles_ProfileRProfileID",
                table: "ServiceRequest",
                column: "ProfileRProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Services_ServiceRServiceID",
                table: "ServiceRequest",
                column: "ServiceRServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "ServiceRequest",
                newName: "Requests");
        }
    }
}
