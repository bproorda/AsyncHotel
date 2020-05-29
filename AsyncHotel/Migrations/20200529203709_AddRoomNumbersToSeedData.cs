using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncHotel.Migrations
{
    public partial class AddRoomNumbersToSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 1, 1 },
                column: "RoomNumber",
                value: 101);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 2, 2 },
                column: "RoomNumber",
                value: 102);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 3, 3 },
                column: "RoomNumber",
                value: 103);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 4, 6 },
                column: "RoomNumber",
                value: 104);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 5, 4 },
                column: "RoomNumber",
                value: 101);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 5, 5 },
                column: "RoomNumber",
                value: 201);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 5, 7 },
                column: "RoomNumber",
                value: 301);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 1, 1 },
                column: "RoomNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 2, 2 },
                column: "RoomNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 3, 3 },
                column: "RoomNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 4, 6 },
                column: "RoomNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 5, 4 },
                column: "RoomNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 5, 5 },
                column: "RoomNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 5, 7 },
                column: "RoomNumber",
                value: 0);
        }
    }
}
