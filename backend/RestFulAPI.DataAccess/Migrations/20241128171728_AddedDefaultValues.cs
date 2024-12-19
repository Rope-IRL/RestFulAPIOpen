using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFulAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                oldScale: 1);

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
                oldScale: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "LesseeAdditionalInfos",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldDefaultValue: 0.0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "LandlordAdditionalInfos",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldDefaultValue: 0.0m);
        }
    }
}
