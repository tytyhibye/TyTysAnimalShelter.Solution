using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Species = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Description", "ImageUrl", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 5, "Very boop-able. Loves bellyrubs.", "", "Herman", "Cat" },
                    { 2, 3, "A prince among floofs. He only eats organic free-range waygu beef. Requires nightly brushing", "", "Chanteclaire", "Dog" },
                    { 3, 42, "Yes THAT Garfield. Retired hollywood cat looking for a fresh start. Loves Lazagna, hates mondays and requires diabetic medication.", "", "Garfield", "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "test", null, "Tyler" },
                    { 2, "itsyou", null, "MyFavoriteInstructor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
