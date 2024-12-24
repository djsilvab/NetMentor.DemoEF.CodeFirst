using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetMentor.DemoEF.CodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "State",
                table: "Users",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DeletedTimeUtc", "State" },
                values: new object[] { null, (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Users");
        }
    }
}
