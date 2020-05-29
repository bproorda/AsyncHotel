using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncHotel.Migrations
{
    public partial class FixedHotelRoomCK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomId" });
        }
    }
}
