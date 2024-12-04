using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMangementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Halls_HallId",
                table: "ShowTimes");

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "ShowTimes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Halls_HallId",
                table: "ShowTimes",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowTimes_Halls_HallId",
                table: "ShowTimes");

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "ShowTimes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTimes_Halls_HallId",
                table: "ShowTimes",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id");
        }
    }
}
