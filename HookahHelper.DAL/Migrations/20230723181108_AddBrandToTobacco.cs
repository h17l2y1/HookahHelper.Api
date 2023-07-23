using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandToTobacco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandId",
                table: "Tobaccos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tobaccos_BrandId",
                table: "Tobaccos",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tobaccos_Brands_BrandId",
                table: "Tobaccos",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tobaccos_Brands_BrandId",
                table: "Tobaccos");

            migrationBuilder.DropIndex(
                name: "IX_Tobaccos_BrandId",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Tobaccos");
        }
    }
}
