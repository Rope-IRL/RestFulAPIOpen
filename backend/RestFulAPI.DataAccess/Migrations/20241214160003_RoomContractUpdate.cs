using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFulAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoomContractUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AverageMark",
                table: "Rooms",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "NumberOfFloors",
                table: "Rooms",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "NumberOfRooms",
                table: "Rooms",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "Flats",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageMark",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NumberOfFloors",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Rooms");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageMark",
                table: "Flats",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldNullable: true);
        }
    }
}
