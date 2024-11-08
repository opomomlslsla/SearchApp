using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0118c7f2-8d26-4df6-b776-1a3638031a68"), "Груша" },
                    { new Guid("0c6434f3-4702-4c6b-a777-3c8cbaf93058"), "бебра" },
                    { new Guid("0c7d59c3-3bd5-432a-8732-d9e6b3023334"), "Ароматизатор - Груша" },
                    { new Guid("2b307bc9-8727-4365-9fef-a2d035b8449d"), "Пирожок с яблоком" },
                    { new Guid("4e7f8a0b-b2d2-497b-89e2-9b971e09d71d"), "Яблоко" },
                    { new Guid("5c87ceea-0e76-414b-9475-31d03f57abff"), "Грушевый торт" },
                    { new Guid("6ed0138a-7ef3-4e84-8adb-0fd001466f03"), "Яблочное варенье" },
                    { new Guid("a10505b5-0737-496c-89f4-a6f1d8c8fec4"), "Книга рецептов - Груши, Яблоки" },
                    { new Guid("a1f87413-0fb7-47c8-8859-d51a5d7feb3c"), "что-то с яблоком" },
                    { new Guid("c0bf3521-226d-4b50-9c48-1a8b85c127f3"), "Игрушка - груша" },
                    { new Guid("c8291708-5ece-4f60-95f7-1366561c12a8"), "Яблочный пирог" },
                    { new Guid("cc18355d-4f24-4dcc-9340-d36d0609d4e9"), "Варенье с грушей" },
                    { new Guid("fe36cdf9-322d-46fe-8396-fa6e0dab6d98"), "Яблочный суп" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
