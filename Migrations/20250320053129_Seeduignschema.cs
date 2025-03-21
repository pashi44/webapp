using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Migrations
{
    /// <inheritdoc />
    public partial class Seeduignschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("f4b5ebbe-a0d2-4419-b005-6ce6557130ba"));

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ContactName", "Description", "DueDate", "InvoiceDate", "InvoiceNumber", "Status" },
                values: new object[] { new Guid("beea2769-ab1e-4fb4-b50e-efdc96d74256"), 100.0, "Iron Man", "Invoice for the first month", new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-001", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("beea2769-ab1e-4fb4-b50e-efdc96d74256"));

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ContactName", "Description", "DueDate", "InvoiceDate", "InvoiceNumber", "Status" },
                values: new object[] { new Guid("f4b5ebbe-a0d2-4419-b005-6ce6557130ba"), 100.0, "Iron Man", "Invoice for the first month", new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-001", 1 });
        }
    }
}
