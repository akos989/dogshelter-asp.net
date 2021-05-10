using Microsoft.EntityFrameworkCore.Migrations;

namespace DogShelter.Migrations
{
    public partial class UpdateDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Shelter_ShelterId",
                table: "Dog");

            migrationBuilder.AlterColumn<long>(
                name: "ShelterId",
                table: "Dog",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Shelter_ShelterId",
                table: "Dog",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Shelter_ShelterId",
                table: "Dog");

            migrationBuilder.AlterColumn<long>(
                name: "ShelterId",
                table: "Dog",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Shelter_ShelterId",
                table: "Dog",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
