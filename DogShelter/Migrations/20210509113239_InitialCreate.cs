using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DogShelter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false, defaultValue: 0),
                    Breed = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dog",
                columns: new[] { "Id", "Age", "Breed", "Name" },
                values: new object[,]
                {
                    { 2L, 14, "Beagle", "Lulu" },
                    { 1L, 1, "Jack Russel Terrier", "Zsuli" },
                    { 3L, 1, "cuki", "Füge" },
                    { 4L, 15, "Valami", "Guszti" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dog");
        }
    }
}
