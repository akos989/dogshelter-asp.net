using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DogShelter.Migrations
{
    public partial class AddShelterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShelterId",
                table: "Dog",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shelter",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1L, "Gödöllő", "Gödöllői menhely" });

            migrationBuilder.InsertData(
                table: "Shelter",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 2L, "Szada", "Lelenc menhely" });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Age", "ShelterId" },
                values: new object[] { 1, 1L });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Age", "ShelterId" },
                values: new object[] { 14, 1L });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Age", "Breed", "ShelterId" },
                values: new object[] { 1, "Cuki", 2L });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Age", "ShelterId" },
                values: new object[] { 15, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Dog_ShelterId",
                table: "Dog",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Shelter_ShelterId",
                table: "Dog",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Shelter_ShelterId",
                table: "Dog");

            migrationBuilder.DropTable(
                name: "Shelter");

            migrationBuilder.DropIndex(
                name: "IX_Dog_ShelterId",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "ShelterId",
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
                columns: new[] { "Age", "Breed" },
                values: new object[] { 1, "cuki" });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Age",
                value: 15);
        }
    }
}
