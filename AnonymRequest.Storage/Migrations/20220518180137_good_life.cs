using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymRequest.Storage.Migrations
{
    public partial class good_life : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInfos_Comments_comment",
                table: "TicketInfos");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "TicketInfos",
                newName: "comment_id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInfos_comment",
                table: "TicketInfos",
                newName: "IX_TicketInfos_comment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInfos_Comments_comment_id",
                table: "TicketInfos",
                column: "comment_id",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInfos_Comments_comment_id",
                table: "TicketInfos");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "TicketInfos",
                newName: "comment");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInfos_comment_id",
                table: "TicketInfos",
                newName: "IX_TicketInfos_comment");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInfos_Comments_comment",
                table: "TicketInfos",
                column: "comment",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
