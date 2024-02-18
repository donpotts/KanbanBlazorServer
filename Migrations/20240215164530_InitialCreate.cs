using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KanbanBlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Data",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Make dinner", "To Do" },
                    { 2, "Clean kitchen", "To Do" },
                    { 3, "Clean dishes and load dishwasher", "To Do" },
                    { 4, "Exercise", "In Process" },
                    { 5, "Make a journal entry", "In Process" },
                    { 6, "Check morning email", "In Process" },
                    { 7, "Make morning coffee", "Done" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");
        }
    }
}
