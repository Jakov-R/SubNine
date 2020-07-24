using Microsoft.EntityFrameworkCore.Migrations;

namespace SubNineAPI.Migrations
{
    public partial class addnewvaluestodatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "running" },
                    { 2L, "jumping" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Hrvatska" },
                    { 2L, "Bosna i Hercegovina" }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "100m" },
                    { 2L, "long jump" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Preliminary round" },
                    { 2L, "Qualifications" },
                    { 3L, "Heats" }
                });

            migrationBuilder.InsertData(
                table: "Participations",
                columns: new[] { "Id", "Result" },
                values: new object[,]
                {
                    { 1L, 10.970000000000001 },
                    { 2L, 22.219999999999999 }
                });

            migrationBuilder.InsertData(
                table: "RangLists",
                columns: new[] { "Id", "Place" },
                values: new object[,]
                {
                    { 1L, 4 },
                    { 2L, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Participations",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Participations",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RangLists",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RangLists",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
