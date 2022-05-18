using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymRequest.Storage.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInfos_Files_files",
                table: "TicketInfos");

            migrationBuilder.RenameColumn(
                name: "files",
                table: "TicketInfos",
                newName: "files_id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInfos_files",
                table: "TicketInfos",
                newName: "IX_TicketInfos_files_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInfos_Files_files_id",
                table: "TicketInfos",
                column: "files_id",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInfos_Files_files_id",
                table: "TicketInfos");

            migrationBuilder.RenameColumn(
                name: "files_id",
                table: "TicketInfos",
                newName: "files");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInfos_files_id",
                table: "TicketInfos",
                newName: "IX_TicketInfos_files");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInfos_Files_files",
                table: "TicketInfos",
                column: "files",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
