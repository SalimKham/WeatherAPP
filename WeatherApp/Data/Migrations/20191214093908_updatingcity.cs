using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Data.Migrations
{
    public partial class updatingcity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "temp",
                table: "cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "weatherDesc",
                table: "cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "windSpeed",
                table: "cities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "temp",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "weatherDesc",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "windSpeed",
                table: "cities");
        }
    }
}
