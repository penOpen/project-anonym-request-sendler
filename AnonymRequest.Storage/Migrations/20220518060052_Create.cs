using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymRequest.Storage.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_mod = table.Column<bool>(type: "bit", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Mods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avatar = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "TicketInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    files = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketInfos_Files_files",
                        column: x => x.files,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_mod = table.Column<int>(type: "int", nullable: false),
                    id_ticketinfo = table.Column<int>(type: "int", nullable: false),
                    id_comments = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Comments_id_comments",
                        column: x => x.id_comments,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Mods_id_mod",
                        column: x => x.id_mod,
                        principalTable: "Mods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketInfos_id_ticketinfo",
                        column: x => x.id_ticketinfo,
                        principalTable: "TicketInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticket_id = table.Column<int>(type: "int", nullable: false),
                    comment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketComments_Comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketComments_Tickets_ticket_id",
                        column: x => x.ticket_id,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_id = table.Column<int>(type: "int", nullable: false),
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketFiles_Files_File_id",
                        column: x => x.File_id,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketFiles_Tickets_ticket_id",
                        column: x => x.ticket_id,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticketguids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_ticket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticketguids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticketguids_Tickets_id_ticket",
                        column: x => x.id_ticket,
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
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_CommentFiles_comment_id",
                table: "CommentFiles",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_CommentFiles_file_id",
                table: "CommentFiles",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mods_avatar",
                table: "Mods",
                column: "avatar");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_comment_id",
                table: "TicketComments",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_ticket_id",
                table: "TicketComments",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFiles_File_id",
                table: "TicketFiles",
                column: "File_id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketFiles_ticket_id",
                table: "TicketFiles",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticketguids_id_ticket",
                table: "Ticketguids",
                column: "id_ticket");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInfos_files",
                table: "TicketInfos",
                column: "files");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_id_comments",
                table: "Tickets",
                column: "id_comments");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_id_mod",
                table: "Tickets",
                column: "id_mod");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_id_ticketinfo",
                table: "Tickets",
                column: "id_ticketinfo");

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
                name: "TicketComments");

            migrationBuilder.DropTable(
                name: "TicketFiles");

            migrationBuilder.DropTable(
                name: "Ticketguids");

            migrationBuilder.DropTable(
                name: "TicketTokens");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Mods");

            migrationBuilder.DropTable(
                name: "TicketInfos");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
