using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymRequest.Storage.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_id = table.Column<int>(type: "int", nullable: false),
                    ticketinfo_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketFiles_Files_file_id",
                        column: x => x.file_id,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketFiles_TicketInfos_ticketinfo_id",
                        column: x => x.ticketinfo_id,
                        principalTable: "TicketInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avatar = table.Column<int>(type: "int", nullable: false),
                    id_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mods_Files_avatar",
                        column: x => x.avatar,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mods_Types_id_type",
                        column: x => x.id_type,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ticketinfo = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketInfos_id_ticketinfo",
                        column: x => x.id_ticketinfo,
                        principalTable: "TicketInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Types_typeid",
                        column: x => x.typeid,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_mod = table.Column<bool>(type: "bit", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<long>(type: "bigint", nullable: false),
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Tickets_ticket_id",
                        column: x => x.ticket_id,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key_token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTokens_Tickets_ticket_id",
                        column: x => x.ticket_id,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment_id = table.Column<int>(type: "int", nullable: false),
                    file_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentFiles_Comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentFiles_Files_file_id",
                        column: x => x.file_id,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentFiles_comment_id",
                table: "CommentFiles",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_CommentFiles_file_id",
                table: "CommentFiles",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ticket_id",
                table: "Comments",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mods_avatar",
                table: "Mods",
                column: "avatar");

            migrationBuilder.CreateIndex(
                name: "IX_Mods_id_type",
                table: "Mods",
                column: "id_type");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFiles_file_id",
                table: "TicketFiles",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFiles_ticketinfo_id",
                table: "TicketFiles",
                column: "ticketinfo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_id_ticketinfo",
                table: "Tickets",
                column: "id_ticketinfo");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_typeid",
                table: "Tickets",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTokens_ticket_id",
                table: "TicketTokens",
                column: "ticket_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentFiles");

            migrationBuilder.DropTable(
                name: "Mods");

            migrationBuilder.DropTable(
                name: "TicketFiles");

            migrationBuilder.DropTable(
                name: "TicketTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketInfos");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
