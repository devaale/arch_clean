using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean_Architecture.Infrastructure.Persistence.Migrations
{
    public partial class Newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Failed",
                table: "TodoItems",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Failed",
                table: "TodoItems");
        }
    }
}
