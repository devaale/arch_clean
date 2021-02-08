using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean_Architecture.Infrastructure.Persistence.Migrations
{
    public partial class RecordsAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Records",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Records",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FkPlcBlockId",
                table: "Records",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceivedFrom",
                table: "Records",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RfidCode",
                table: "Records",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SentTo",
                table: "Records",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Records",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Records_FkPlcBlockId",
                table: "Records",
                column: "FkPlcBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_PlcBlocks_FkPlcBlockId",
                table: "Records",
                column: "FkPlcBlockId",
                principalTable: "PlcBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_PlcBlocks_FkPlcBlockId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_FkPlcBlockId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "FkPlcBlockId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "ReceivedFrom",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "RfidCode",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "SentTo",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Records");
        }
    }
}
