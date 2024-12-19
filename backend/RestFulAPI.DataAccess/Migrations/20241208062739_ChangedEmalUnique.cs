using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFulAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEmalUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Landlords_Email",
                table: "Landlords");

            migrationBuilder.DropIndex(
                name: "IX_LandlordAdditionalInfos_LandlordId",
                table: "LandlordAdditionalInfos");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "LesseeAdditionalInfos",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: true,
                defaultValue: 0.0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldDefaultValue: 0.0m);

            migrationBuilder.AlterColumn<int>(
                name: "LandlordId",
                table: "LandlordAdditionalInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "LandlordAdditionalInfos",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: true,
                defaultValue: 0.0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldDefaultValue: 0.0m);

            migrationBuilder.CreateIndex(
                name: "IX_LandlordAdditionalInfos_LandlordId",
                table: "LandlordAdditionalInfos",
                column: "LandlordId",
                unique: true,
                filter: "[LandlordId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LandlordAdditionalInfos_LandlordId",
                table: "LandlordAdditionalInfos");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "LesseeAdditionalInfos",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: false,
                defaultValue: 0.0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldNullable: true,
                oldDefaultValue: 0.0m);

            migrationBuilder.AlterColumn<int>(
                name: "LandlordId",
                table: "LandlordAdditionalInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "LandlordAdditionalInfos",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: false,
                defaultValue: 0.0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldNullable: true,
                oldDefaultValue: 0.0m);

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_Email",
                table: "Landlords",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandlordAdditionalInfos_LandlordId",
                table: "LandlordAdditionalInfos",
                column: "LandlordId",
                unique: true);
        }
    }
}
