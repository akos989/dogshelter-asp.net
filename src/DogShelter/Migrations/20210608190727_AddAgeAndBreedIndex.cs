using Microsoft.EntityFrameworkCore.Migrations;

namespace DogShelter.Migrations
{
    public partial class AddAgeAndBreedIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Age",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Age",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Age",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Age",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Age",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Age",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Age",
                value: 15);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8dc76956-948f-4f65-96d4-e52adc63f4d2", "AQAAAAEAACcQAAAAEEv5EW7omdi69aZKbpHiddqy7Rk1KsrS1hdalbfZzJr96QHAuV7SMkU1I2+A3SlmzA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47f47b57-d1cd-42f0-9c6b-fa817f236df6", "AQAAAAEAACcQAAAAEKoK+4qPe8+ajpNSmxH0kPpUBZkc14tafVneUdiV+7q4Ri5ZS8N3cj5Ni3s4T0t9Xw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05306314-ce34-45dd-b355-e1476a8ed731", "AQAAAAEAACcQAAAAEC974QNhEX8RMKTqo+kJPNN+JRlwCmk+iPqxyBzkROaH+rEwUqhNpQ1xLcbnbEyizQ==" });

            migrationBuilder.CreateIndex(
                name: "Age_Breed_Index",
                table: "Dog",
                columns: new[] { "Age", "Breed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Age_Breed_Index",
                table: "Dog");

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Age",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Age",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Age",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Age",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Age",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Age",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Age",
                value: 15);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "66ef9c50-38af-4182-9655-ec740893ab6b", "AQAAAAEAACcQAAAAEA0o1Nk05+qtDtmhQeaQNFKwU4mXmdfHJRq7AWP6/Kf6PwzfVZnj929mJXsFH4xp8w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4878037-9310-4342-941e-7a8381e5cb85", "AQAAAAEAACcQAAAAECgK/ZT/pl8llOSJ3byPGE1cgSAS8lhn+UZP+uI93Zk/Ghf4bY5nsYNqkWRV/1UUFg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "36d91a45-67b3-458a-b48d-2ff6461d763c", "AQAAAAEAACcQAAAAEAaPUG/Ag+OhqhT0+BgBJVFnBuIqL80Mlt5eoREVO1ft+l5/N6VmzeMz1hl48o2fWw==" });
        }
    }
}
