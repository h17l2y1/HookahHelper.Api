using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingToMix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Mixes",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Mixes");
        }
    }
}
