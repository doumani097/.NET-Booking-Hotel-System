using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.DataAccess.Migrations
{
    public partial class AddTotalPriceAfterDiscountToBookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPriceAfterDiscount",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPriceAfterDiscount",
                table: "Bookings");
        }
    }
}
