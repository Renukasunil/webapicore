using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LMS.Data.Migrations
{
    public partial class migrationloginclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblLogin",
                table: "TblLogin");

            migrationBuilder.RenameTable(
                name: "TblLogin",
                newName: "Login");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Login",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "LoginId",
                table: "Login",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "LoginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Login");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "TblLogin");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TblLogin",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblLogin",
                table: "TblLogin",
                column: "UserId");
        }
    }
}
