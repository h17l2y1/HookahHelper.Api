using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tobaccos_Images_ImageId",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Acidity",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Fortress",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Freshness",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Smokiness",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Spice",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Sweetness",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "Tobaccos");

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Tobaccos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tobaccos_Images_ImageId",
                table: "Tobaccos",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tobaccos_Images_ImageId",
                table: "Tobaccos");

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Tobaccos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<float>(
                name: "Acidity",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fortress",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Freshness",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Smokiness",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Spice",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Sweetness",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Taste",
                table: "Tobaccos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Tobaccos_Images_ImageId",
                table: "Tobaccos",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
