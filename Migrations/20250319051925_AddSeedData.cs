using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InvoiceNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    InvoiceDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "Id", "Amount", "ContactName", "Description", "DueDate", "InvoiceDate", "InvoiceNumber", "Status" },
                values: new object[] { new Guid("80061cee-af8f-4856-9c44-2a6e56eb17b4"), 100m, "Iron Man", "Invoice for the first month", new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-001", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
