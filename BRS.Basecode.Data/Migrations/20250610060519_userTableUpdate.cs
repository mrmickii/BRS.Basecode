using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BRS.Basecode.Data.Migrations
{
    public partial class userTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserPin",
                table: "Users",
                newName: "User_Pin");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Users",
                newName: "Date_Created");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "User_Pin",
                table: "Users",
                newName: "UserPin");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                table: "Users",
                newName: "DateCreated");
        }
    }
}
