using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AhmedRabieTechnicalTask.Infra.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Active", "Auther", "Deleted", "Description", "MaxSalePrice", "MinSalePrice", "PublishDate", "Title" },
                values: new object[] { new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), true, "Ahmed Mohamed", false, "Ahmed Rabie Book Desctiption", 100.0, 50.0, new DateTime(2024, 1, 16, 2, 20, 28, 579, DateTimeKind.Local), "Ahmed Rabie Book Title " });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Active", "Auther", "Deleted", "Description", "MaxSalePrice", "MinSalePrice", "PublishDate", "Title" },
                values: new object[] { new Guid("5b29fc40-ca47-1067-b31d-00dd010662da"), true, "Mohamed Mohamed", false, "Mohamed Title Book Desctiption", 100.0, 70.0, new DateTime(2024, 1, 16, 2, 20, 28, 584, DateTimeKind.Local), "Mohamed Title " });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Active", "Auther", "Deleted", "Description", "MaxSalePrice", "MinSalePrice", "PublishDate", "Title" },
                values: new object[] { new Guid("4b29fc40-ca47-1067-b31d-00dd010662da"), true, "Mohamed Mohamed", false, "Mohamed Title Book Desctiption", 100.0, 70.0, new DateTime(2024, 1, 16, 2, 20, 28, 584, DateTimeKind.Local), "Mohamed Title 4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b29fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5b29fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"));
        }
    }
}
