using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddGlobalTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "Tags",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "Tags");
        }
    }
}
