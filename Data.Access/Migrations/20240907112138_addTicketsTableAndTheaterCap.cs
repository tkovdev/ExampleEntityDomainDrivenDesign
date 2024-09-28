using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Access.Migrations
{
    /// <inheritdoc />
    public partial class addTicketsTableAndTheaterCap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Capacity",
                table: "Theaters",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ShowingTheaterId = table.Column<int>(type: "int", nullable: false),
                    ShowingMovieId = table.Column<int>(type: "int", nullable: false),
                    ShowingStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Showings_ShowingTheaterId_ShowingMovieId_ShowingStartTime",
                        columns: x => new { x.ShowingTheaterId, x.ShowingMovieId, x.ShowingStartTime },
                        principalTable: "Showings",
                        principalColumns: new[] { "TheaterId", "MovieId", "StartTime" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowingTheaterId_ShowingMovieId_ShowingStartTime",
                table: "Tickets",
                columns: new[] { "ShowingTheaterId", "ShowingMovieId", "ShowingStartTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Theaters");
        }
    }
}
