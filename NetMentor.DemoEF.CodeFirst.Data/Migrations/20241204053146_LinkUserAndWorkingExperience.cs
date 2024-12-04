using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetMentor.DemoEF.CodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkUserAndWorkingExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperiences_UserId",
                table: "WorkingExperiences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperiences_Users_UserId",
                table: "WorkingExperiences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperiences_Users_UserId",
                table: "WorkingExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkingExperiences_UserId",
                table: "WorkingExperiences");
        }
    }
}
