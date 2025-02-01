using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AlterRelationOnAddressAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_userAddress_UserId",
                table: "userAddress");

            migrationBuilder.CreateIndex(
                name: "IX_userAddress_UserId",
                table: "userAddress",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_userAddress_UserId",
                table: "userAddress");

            migrationBuilder.CreateIndex(
                name: "IX_userAddress_UserId",
                table: "userAddress",
                column: "UserId");
        }
    }
}
