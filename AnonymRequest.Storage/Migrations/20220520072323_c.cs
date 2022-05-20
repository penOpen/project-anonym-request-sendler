﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymRequest.Storage.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mods_Files_avatar",
                table: "Mods");

            migrationBuilder.AlterColumn<int>(
                name: "avatar",
                table: "Mods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Mods_Files_avatar",
                table: "Mods",
                column: "avatar",
                principalTable: "Files",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mods_Files_avatar",
                table: "Mods");

            migrationBuilder.AlterColumn<int>(
                name: "avatar",
                table: "Mods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mods_Files_avatar",
                table: "Mods",
                column: "avatar",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
