using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestFulAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AverageMark = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfRooms = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfFloors = table.Column<short>(type: "smallint", nullable: false),
                    IsBathroomAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsWiFiAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "MONEY", precision: 18, scale: 2, nullable: false),
                    LlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_Landlords_LlId",
                        column: x => x.LlId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageMark = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Landlords_LlId",
                        column: x => x.LlId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageMark = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfRooms = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfFloors = table.Column<short>(type: "smallint", nullable: false),
                    IsBathroomAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsWiFiAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "MONEY", precision: 18, scale: 2, nullable: false),
                    LlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Landlords_LlId",
                        column: x => x.LlId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandlordAdditionalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PassportId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AverageMark = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandlordAdditionalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandlordAdditionalInfos_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LesseeAdditionalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PassportId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AverageMark = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
                    LesseeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesseeAdditionalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LesseeAdditionalInfos_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlatContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Cost = table.Column<decimal>(type: "MONEY", precision: 18, scale: 2, nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    LesseeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlatContracts_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlatContracts_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlatContracts_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsBathroomAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsWiFiAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "MONEY", precision: 18, scale: 2, nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Cost = table.Column<decimal>(type: "MONEY", precision: 18, scale: 2, nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    LesseeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseContracts_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseContracts_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseContracts_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Cost = table.Column<decimal>(type: "MONEY", precision: 18, scale: 2, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    LesseeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomContracts_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomContracts_Lessees_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomContracts_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlatContracts_FlatId",
                table: "FlatContracts",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_FlatContracts_LandlordId",
                table: "FlatContracts",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_FlatContracts_LesseeId",
                table: "FlatContracts",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_LlId",
                table: "Flats",
                column: "LlId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LlId",
                table: "Hotels",
                column: "LlId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseContracts_HouseId",
                table: "HouseContracts",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseContracts_LandlordId",
                table: "HouseContracts",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseContracts_LesseeId",
                table: "HouseContracts",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_LlId",
                table: "Houses",
                column: "LlId");

            migrationBuilder.CreateIndex(
                name: "IX_LandlordAdditionalInfos_LandlordId",
                table: "LandlordAdditionalInfos",
                column: "LandlordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_Email",
                table: "Landlords",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LesseeAdditionalInfos_LesseeId",
                table: "LesseeAdditionalInfos",
                column: "LesseeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessees_Email",
                table: "Lessees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomContracts_LandlordId",
                table: "RoomContracts",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomContracts_LesseeId",
                table: "RoomContracts",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomContracts_RoomId",
                table: "RoomContracts",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlatContracts");

            migrationBuilder.DropTable(
                name: "HouseContracts");

            migrationBuilder.DropTable(
                name: "LandlordAdditionalInfos");

            migrationBuilder.DropTable(
                name: "LesseeAdditionalInfos");

            migrationBuilder.DropTable(
                name: "RoomContracts");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Lessees");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Landlords");
        }
    }
}
