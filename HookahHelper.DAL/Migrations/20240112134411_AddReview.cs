using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mixes_Ratings_RatingId",
                table: "Mixes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tobaccos_TobaccoRatings_TobaccoRatingId",
                table: "Tobaccos");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "TobaccoRatings");

            migrationBuilder.DropIndex(
                name: "IX_Tobaccos_TobaccoRatingId",
                table: "Tobaccos");

            migrationBuilder.DropIndex(
                name: "IX_Mixes_RatingId",
                table: "Mixes");

            migrationBuilder.DropColumn(
                name: "TobaccoRatingId",
                table: "Tobaccos");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Mixes");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TobaccoId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    AnonymousName = table.Column<string>(type: "text", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    MixId = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Mixes_MixId",
                        column: x => x.MixId,
                        principalTable: "Mixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Tobaccos_TobaccoId",
                        column: x => x.TobaccoId,
                        principalTable: "Tobaccos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MixId",
                table: "Reviews",
                column: "MixId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TobaccoId",
                table: "Reviews",
                column: "TobaccoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "TobaccoRatingId",
                table: "Tobaccos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RatingId",
                table: "Mixes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TobaccoRatings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<float>(type: "real", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TobaccoRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TobaccoRatingId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_TobaccoRatings_TobaccoRatingId",
                        column: x => x.TobaccoRatingId,
                        principalTable: "TobaccoRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RatingId = table.Column<string>(type: "text", nullable: false),
                    TobaccoId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Tobaccos_TobaccoId",
                        column: x => x.TobaccoId,
                        principalTable: "Tobaccos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tobaccos_TobaccoRatingId",
                table: "Tobaccos",
                column: "TobaccoRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Mixes_RatingId",
                table: "Mixes",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RatingId",
                table: "Comments",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TobaccoId",
                table: "Comments",
                column: "TobaccoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TobaccoRatingId",
                table: "Ratings",
                column: "TobaccoRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mixes_Ratings_RatingId",
                table: "Mixes",
                column: "RatingId",
                principalTable: "Ratings",
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
    }
}
