using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorVaruska.Server.Data.Migrations
{
    public partial class AddVaruskaDummy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Varuska",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Varuska",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Varuska",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Varuska_CityId",
                table: "Varuska",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Varuska_City_CityId",
                table: "Varuska",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varuska_City_CityId",
                table: "Varuska");

            migrationBuilder.DropIndex(
                name: "IX_Varuska_CityId",
                table: "Varuska");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Varuska");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Varuska");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Varuska");
        }
    }
}
