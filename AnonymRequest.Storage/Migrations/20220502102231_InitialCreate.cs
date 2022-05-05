using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymRequest.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _InstationId = table.Column<int>(type: "int", nullable: false),
                    _Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Instation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _UserToken = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Requests_Users__UserToken",
                        column: x => x._UserToken,
                        principalTable: "Users",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instations",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _name_of_instation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _agent_of_instation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instations", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Instations_Requests__RequestId",
                        column: x => x._RequestId,
                        principalTable: "Requests",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Status = table.Column<bool>(type: "bit", nullable: true),
                    _RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Requests__RequestId",
                        column: x => x._RequestId,
                        principalTable: "Requests",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Working_hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _InstationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Agents_Instations__InstationId",
                        column: x => x._InstationId,
                        principalTable: "Instations",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents__InstationId",
                table: "Agents",
                column: "_InstationId");

            migrationBuilder.CreateIndex(
                name: "IX_Instations__RequestId",
                table: "Instations",
                column: "_RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests__UserToken",
                table: "Requests",
                column: "_UserToken");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses__RequestId",
                table: "Statuses",
                column: "_RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Instations");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
