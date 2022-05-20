using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymRequest.Storage.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "Mods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "Mods");
        }
    }
}
