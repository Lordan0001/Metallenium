using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metallenium_backend.API.Migrations
{
    public partial class userchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserFullName",
                table: "Users",
                newName: "UserSecondName");

            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserSecondName",
                table: "Users",
                newName: "UserFullName");
        }
    }
}
