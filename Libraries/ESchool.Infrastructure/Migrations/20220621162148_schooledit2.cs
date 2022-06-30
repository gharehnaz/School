using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESchool.Infrastructure.Migrations
{
    public partial class schooledit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Accounts_AccountId",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_AccountId",
                table: "School");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "School",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 21, 20, 51, 47, 807, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 21, 20, 51, 47, 811, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 21, 20, 51, 47, 811, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SchoolId",
                table: "Accounts",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_School_SchoolId",
                table: "Accounts",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_School_SchoolId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_SchoolId",
                table: "Accounts");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "School",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 20, 17, 49, 26, 875, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 20, 17, 49, 26, 879, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 20, 17, 49, 26, 879, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.CreateIndex(
                name: "IX_School_AccountId",
                table: "School",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Accounts_AccountId",
                table: "School",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
