using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.DataAccess.Migrations
{
    public partial class MissingDataAnnotationsThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_HotelLocations_HotelId",
            //    table: "HotelLocations");

            //migrationBuilder.DropIndex(
            //    name: "IX_HotelLocations_LocationId",
            //    table: "HotelLocations");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HotelLocations_HotelId",
            //    table: "HotelLocations",
            //    column: "HotelId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_HotelLocations_LocationId",
            //    table: "HotelLocations",
            //    column: "LocationId",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_HotelLocations_HotelId",
            //    table: "HotelLocations");

            //migrationBuilder.DropIndex(
            //    name: "IX_HotelLocations_LocationId",
            //    table: "HotelLocations");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HotelLocations_HotelId",
            //    table: "HotelLocations",
            //    column: "HotelId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HotelLocations_LocationId",
            //    table: "HotelLocations",
            //    column: "LocationId");
        }
    }
}
