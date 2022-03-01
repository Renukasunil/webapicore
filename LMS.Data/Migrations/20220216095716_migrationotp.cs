using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LMS.Data.Migrations
{
    public partial class migrationotp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaveVerifyOTP");

            migrationBuilder.DropTable(
                name: "TblSendOTP");

            migrationBuilder.CreateTable(
                name: "TblOTP",
                columns: table => new
                {
                    VId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OTP = table.Column<string>(type: "text", nullable: true),
                    MobileNo = table.Column<string>(type: "text", nullable: true),
                    GenerateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOTP", x => x.VId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblOTP");

            migrationBuilder.CreateTable(
                name: "SaveVerifyOTP",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenerateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MobileNo = table.Column<string>(type: "text", nullable: true),
                    OTP = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveVerifyOTP", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TblSendOTP",
                columns: table => new
                {
                    VId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MobileNo = table.Column<string>(type: "text", nullable: true),
                    OTP = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSendOTP", x => x.VId);
                });
        }
    }
}
