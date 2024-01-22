using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AhmedRabieTechnicalTask.Infra.Data.Migrations
{
    public partial class updatdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b29fc40-ca47-1067-b31d-00dd010662da"),
                column: "PublishDate",
                value: new DateTime(2024, 1, 22, 16, 59, 20, 842, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5b29fc40-ca47-1067-b31d-00dd010662da"),
                column: "PublishDate",
                value: new DateTime(2024, 1, 22, 16, 59, 20, 842, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"),
                column: "PublishDate",
                value: new DateTime(2024, 1, 22, 16, 59, 20, 835, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b29fc40-ca47-1067-b31d-00dd010662da"),
                column: "PublishDate",
                value: new DateTime(2024, 1, 16, 2, 20, 28, 584, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5b29fc40-ca47-1067-b31d-00dd010662da"),
                column: "PublishDate",
                value: new DateTime(2024, 1, 16, 2, 20, 28, 584, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"),
                column: "PublishDate",
                value: new DateTime(2024, 1, 16, 2, 20, 28, 579, DateTimeKind.Local));
        }
    }
}
