﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IDDemo.Data.Migrations
{
    public partial class RoleClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Role_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaim");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "RoleClaim",
                newName: "IX_RoleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaim",
                table: "RoleClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaim_Role_RoleId",
                table: "RoleClaim",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_Role_RoleId",
                table: "RoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaim",
                table: "RoleClaim");

            migrationBuilder.RenameTable(
                name: "RoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Role_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
