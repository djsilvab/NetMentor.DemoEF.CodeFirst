using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetMentor.DemoEF.CodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntity_to_WorkingExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "WorkingExperiences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "State",
                table: "WorkingExperiences",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "WorkingExperiences");

            migrationBuilder.DropColumn(
                name: "State",
                table: "WorkingExperiences");
        }
    }
}
