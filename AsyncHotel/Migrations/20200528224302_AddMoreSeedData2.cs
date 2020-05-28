using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncHotel.Migrations
{
    public partial class AddMoreSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "AmenityId", "RoomId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "layout", "name" },
                values: new object[,]
                {
                    { 2, 2, "Forest View" },
                    { 3, 3, "Lake View Suite" },
                    { 4, 5, "Rustic Cabin" },
                    { 5, 5, "The Lost Camp" },
                    { 6, 4, "Lover's Leap" },
                    { 7, 5, "The Lighthouse" }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "AmenityId", "RoomId" },
                values: new object[,]
                {
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 6 },
                    { 4, 6 },
                    { 5, 6 },
                    { 4, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenityId", "RoomId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
