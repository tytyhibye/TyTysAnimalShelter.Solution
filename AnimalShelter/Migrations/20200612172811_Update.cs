using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Animals",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Gender", "ImageUrl", "Name" },
                values: new object[] { "Female", "https://www.rover.com/blog/wp-content/uploads/2019/09/funny-cat-960x540.jpg", "Jennifur" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                columns: new[] { "Gender", "ImageUrl" },
                values: new object[] { "Male", "https://www.wallpaperflare.com/static/98/704/904/white-brown-teacup-pomeranian-wallpaper-preview.jpg" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                columns: new[] { "Gender", "ImageUrl" },
                values: new object[] { "Male", "https://i.redd.it/hq4is2vxe4y21.jpg" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Description", "Gender", "ImageUrl", "Name", "Species" },
                values: new object[,]
                {
                    { 4, 14, "Looks like a butthead but he's a big ol' softy once you get to know him.", "Male", "https://i.imgur.com/x9K5JYo.jpg", "Mr.Grump", "Cat" },
                    { 5, 5, "True to her name this gal literally can't stop smiling. Gluten Free", "Female", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQKbCHEc_uRla-QRmnDse9ktweLdkE1C8c2_hD_rD_9MFTKQJKT&usqp=CAU", "Smiley", "Dog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Animals");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "", "Herman" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "ImageUrl",
                value: "");
        }
    }
}
