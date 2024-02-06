using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingTOMIx2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Mixes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Mixes",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
