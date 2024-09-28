using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Access.Migrations
{
    /// <inheritdoc />
    public partial class addMovieRunTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RunTime",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunTime",
                table: "Movies");
        }
    }
}
