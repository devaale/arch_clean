using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean_Architecture.Infrastructure.Persistence.Migrations
{
    public partial class MigrationDroppedUnecessary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Failed",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "NewProperty",
                table: "TodoItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Failed",
                table: "TodoItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewProperty",
                table: "TodoItems",
                type: "TEXT",
                nullable: true);
        }
    }
}
