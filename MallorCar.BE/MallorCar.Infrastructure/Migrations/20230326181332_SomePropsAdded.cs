using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MallorCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SomePropsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RentalCode",
                table: "Rentals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarRegNumber",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalCode",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "CarRegNumber",
                table: "Cars");
        }
    }
}
