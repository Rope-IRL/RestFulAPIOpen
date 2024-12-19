using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFulAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PropertyImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlatImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    MainImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstSmallImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondSmallImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlatImages_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousesImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    MainImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstSmallImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondSmallImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousesImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HousesImage_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    MainImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstSmallImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondSmallImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlatImages_FlatId",
                table: "FlatImages",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_HousesImage_HouseId",
                table: "HousesImage",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlatImages");

            migrationBuilder.DropTable(
                name: "HousesImage");

            migrationBuilder.DropTable(
                name: "RoomImages");
        }
    }
}
