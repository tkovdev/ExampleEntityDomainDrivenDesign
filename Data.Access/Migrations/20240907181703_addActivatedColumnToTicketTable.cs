using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Access.Migrations
{
    /// <inheritdoc />
    public partial class addActivatedColumnToTicketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activated",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activated",
                table: "Tickets");
        }
    }
}
