using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DogShelter.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Shelter",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Dog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Age",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Age",
                value: 1);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Phonenumber" },
                values: new object[,]
                {
                    { 1L, "Ákos", "030134231" },
                    { 2L, "Dani", "244234234" },
                    { 3L, "Virág", "244232334" }
                });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Age", "OwnerId", "ShelterId" },
                values: new object[] { 14, 1L, null });

            migrationBuilder.UpdateData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Age", "OwnerId", "ShelterId" },
                values: new object[] { 15, 2L, null });

            migrationBuilder.UpdateData(
                table: "Shelter",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OwnerId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Shelter",
                keyColumn: "Id",
                keyValue: 2L,
                column: "OwnerId",
                value: 3L);

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_OwnerId",
                table: "Shelter",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dog_OwnerId",
                table: "Dog",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_User_OwnerId",
                table: "Dog",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelter_User_OwnerId",
                table: "Shelter",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_User_OwnerId",
                table: "Dog");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelter_User_OwnerId",
                table: "Shelter");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Shelter_OwnerId",
                table: "Shelter");

            migrationBuilder.DropIndex(
                name: "IX_Dog_OwnerId",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "OwnerId",
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
                columns: new[] { "Age", "ShelterId" },
                values: new object[] { 14, 1L });

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
                columns: new[] { "Age", "ShelterId" },
                values: new object[] { 15, 1L });
        }
    }
}
