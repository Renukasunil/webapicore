using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LMS.Data.Migrations
{
    public partial class migrationcountry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblOTP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaveVerifyOTP",
                table: "SaveVerifyOTP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "ClientLogin");

            migrationBuilder.AlterColumn<string>(
                name: "GenerateTime",
                table: "SaveVerifyOTP",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "SaveVerifyOTP",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "VId",
                table: "SaveVerifyOTP",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "SaveVerifyOTP",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaveVerifyOTP",
                table: "SaveVerifyOTP",
                column: "VId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientLogin",
                table: "ClientLogin",
                column: "LoginId");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaveVerifyOTP",
                table: "SaveVerifyOTP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientLogin",
                table: "ClientLogin");

            migrationBuilder.DropColumn(
                name: "VId",
                table: "SaveVerifyOTP");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "SaveVerifyOTP");

            migrationBuilder.RenameTable(
                name: "ClientLogin",
                newName: "Login");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "SaveVerifyOTP",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GenerateTime",
                table: "SaveVerifyOTP",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaveVerifyOTP",
                table: "SaveVerifyOTP",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "LoginId");

            migrationBuilder.CreateTable(
                name: "TblOTP",
                columns: table => new
                {
                    VId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenerateTime = table.Column<string>(type: "text", nullable: true),
                    MobileNo = table.Column<string>(type: "text", nullable: true),
                    OTP = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOTP", x => x.VId);
                });
        }
    }
}
