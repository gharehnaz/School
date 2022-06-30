using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESchool.Infrastructure.Migrations
{
    public partial class schoolmanager2 : Migration
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
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 19, 17, 0, 42, 578, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 19, 17, 0, 42, 583, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 19, 17, 0, 42, 583, DateTimeKind.Local).AddTicks(316));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2022, 6, 19, 16, 53, 8, 130, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 19, 16, 53, 8, 134, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 6, 19, 16, 53, 8, 134, DateTimeKind.Local).AddTicks(2714));

            migrationBuilder.CreateIndex(
                name: "IX_School_AccountId",
                table: "School",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Accounts_AccountId",
                table: "School",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
