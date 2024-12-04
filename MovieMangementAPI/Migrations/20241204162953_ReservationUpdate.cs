using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMangementAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReservationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_ApplicationUserId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Seats_SeatId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ShowTimes_ShowTimeId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ShowTimeId",
                table: "Reservations",
                newName: "IX_Reservations_ShowTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_SeatId",
                table: "Reservations",
                newName: "IX_Reservations_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ApplicationUserId",
                table: "Reservations",
                newName: "IX_Reservations_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                table: "Reservations",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ShowTimes_ShowTimeId",
                table: "Reservations",
                column: "ShowTimeId",
                principalTable: "ShowTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ShowTimes_ShowTimeId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ShowTimeId",
                table: "Reservation",
                newName: "IX_Reservation_ShowTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SeatId",
                table: "Reservation",
                newName: "IX_Reservation_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservation",
                newName: "IX_Reservation_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_ApplicationUserId",
                table: "Reservation",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Seats_SeatId",
                table: "Reservation",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ShowTimes_ShowTimeId",
                table: "Reservation",
                column: "ShowTimeId",
                principalTable: "ShowTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
