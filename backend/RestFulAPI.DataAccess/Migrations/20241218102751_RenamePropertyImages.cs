using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFulAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamePropertyImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HousesImage_Houses_HouseId",
                table: "HousesImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HousesImage",
                table: "HousesImage");

            migrationBuilder.RenameTable(
                name: "HousesImage",
                newName: "HouseImages");

            migrationBuilder.RenameIndex(
                name: "IX_HousesImage_HouseId",
                table: "HouseImages",
                newName: "IX_HouseImages_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImages_Houses_HouseId",
                table: "HouseImages",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseImages_Houses_HouseId",
                table: "HouseImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages");

            migrationBuilder.RenameTable(
                name: "HouseImages",
                newName: "HousesImage");

            migrationBuilder.RenameIndex(
                name: "IX_HouseImages_HouseId",
                table: "HousesImage",
                newName: "IX_HousesImage_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HousesImage",
                table: "HousesImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HousesImage_Houses_HouseId",
                table: "HousesImage",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
