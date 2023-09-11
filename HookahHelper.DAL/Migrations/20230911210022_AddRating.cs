using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Tobaccos");

            migrationBuilder.AddColumn<string>(
                name: "RatingId",
                table: "Tobaccos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatingId",
                table: "Mixes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    VotedValue = table.Column<int>(type: "int", nullable: false),
                    VotedCount = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tobaccos_RatingId",
                table: "Tobaccos",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Mixes_RatingId",
                table: "Mixes",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mixes_Ratings_RatingId",
                table: "Mixes",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tobaccos_Ratings_RatingId",
                table: "Tobaccos",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mixes_Ratings_RatingId",
                table: "Mixes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tobaccos_Ratings_RatingId",
                table: "Tobaccos");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Tobaccos_RatingId",
                table: "Tobaccos");

            migrationBuilder.DropIndex(
                name: "IX_Mixes_RatingId",
                table: "Mixes");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Mixes");

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Tobaccos",
                type: "real",
                nullable: true);
        }
    }
}
