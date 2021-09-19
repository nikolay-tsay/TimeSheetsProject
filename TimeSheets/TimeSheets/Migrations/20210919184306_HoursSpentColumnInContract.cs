using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheets.Migrations
{
    public partial class HoursSpentColumnInContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoursSpent",
                table: "Contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursSpent",
                table: "Contracts");
        }
    }
}
