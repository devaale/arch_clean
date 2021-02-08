using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean_Architecture.Infrastructure.Persistence.Migrations
{
    public partial class AddedEventsMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkPlcBlockId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_PlcBlocks_FkPlcBlockId",
                        column: x => x.FkPlcBlockId,
                        principalTable: "PlcBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_FkPlcBlockId",
                table: "Events",
                column: "FkPlcBlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
