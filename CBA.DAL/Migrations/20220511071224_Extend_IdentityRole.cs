using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBA.DAL.Migrations
{
    public partial class Extend_IdentityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetRoles");
        }
    }
}
