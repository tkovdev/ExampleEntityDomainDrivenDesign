using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Access.Migrations
{
    /// <inheritdoc />
    public partial class addSeatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SeatRow",
                table: "Tickets",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Row = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TheaterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => new { x.Row, x.Number });
                    table.ForeignKey(
                        name: "FK_Seats_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatRow_SeatNumber",
                table: "Tickets",
                columns: new[] { "SeatRow", "SeatNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TheaterId",
                table: "Seats",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatRow_SeatNumber",
                table: "Tickets",
                columns: new[] { "SeatRow", "SeatNumber" },
                principalTable: "Seats",
                principalColumns: new[] { "Row", "Number" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatRow_SeatNumber",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SeatRow_SeatNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatRow",
                table: "Tickets");
        }
    }
}
