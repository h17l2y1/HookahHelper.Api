using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tobaccos_Ratings_RatingId",
                table: "Tobaccos");

            migrationBuilder.DropIndex(
                name: "IX_Tobaccos_RatingId",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "VotedCount",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "VotedValue",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "TobaccoRatingId",
                table: "Tobaccos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TobaccoRatingId",
                table: "Ratings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Ratings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RatingId",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TobaccoRatings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TobaccoRatings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tobaccos_TobaccoRatingId",
                table: "Tobaccos",
                column: "TobaccoRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TobaccoRatingId",
                table: "Ratings",
                column: "TobaccoRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RatingId",
                table: "Comments",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ratings_RatingId",
                table: "Comments",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_TobaccoRatings_TobaccoRatingId",
                table: "Ratings",
                column: "TobaccoRatingId",
                principalTable: "TobaccoRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tobaccos_TobaccoRatings_TobaccoRatingId",
                table: "Tobaccos",
                column: "TobaccoRatingId",
                principalTable: "TobaccoRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ratings_RatingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_TobaccoRatings_TobaccoRatingId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tobaccos_TobaccoRatings_TobaccoRatingId",
                table: "Tobaccos");

            migrationBuilder.DropTable(
                name: "TobaccoRatings");

            migrationBuilder.DropIndex(
                name: "IX_Tobaccos_TobaccoRatingId",
                table: "Tobaccos");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_TobaccoRatingId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RatingId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TobaccoRatingId",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "TobaccoRatingId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "RatingId",
                table: "Tobaccos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VotedCount",
                table: "Ratings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VotedValue",
                table: "Ratings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tobaccos_RatingId",
                table: "Tobaccos",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tobaccos_Ratings_RatingId",
                table: "Tobaccos",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
