using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAPI.DataAccess.Migrations
{
    public partial class AddBookingIdPropToReservationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "BookingId",
            //    table: "Reservations",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservations_BookingId",
            //    table: "Reservations",
            //    column: "BookingId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Reservations_Bookings_BookingId",
            //    table: "Reservations",
            //    column: "BookingId",
            //    principalTable: "Bookings",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Reservations_Bookings_BookingId",
            //    table: "Reservations");

            //migrationBuilder.DropIndex(
            //    name: "IX_Reservations_BookingId",
            //    table: "Reservations");

            //migrationBuilder.DropColumn(
            //    name: "BookingId",
            //    table: "Reservations");
        }
    }
}
