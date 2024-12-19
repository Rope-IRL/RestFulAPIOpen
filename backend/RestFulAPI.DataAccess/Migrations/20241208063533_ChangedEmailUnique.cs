using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFulAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEmailUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Landlords_Email",
                table: "Landlords",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Landlords_Email",
                table: "Landlords");
        }
    }
}
