using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPCoreRestfulApiDemo.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FileUploads",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Employees",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32) CHARACTER SET utf8mb4",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Employees",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32) CHARACTER SET utf8mb4",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Companies",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32) CHARACTER SET utf8mb4",
                oldMaxLength: 32);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "FileUploads",
                type: "char(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(Guid),
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Employees",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Employees",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Companies",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 36);
        }
    }
}
