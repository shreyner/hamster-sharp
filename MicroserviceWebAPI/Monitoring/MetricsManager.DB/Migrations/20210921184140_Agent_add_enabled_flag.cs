using Microsoft.EntityFrameworkCore.Migrations;

namespace MetricsManager.DB.Migrations
{
    public partial class Agent_add_enabled_flag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Agents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Agents");
        }
    }
}
