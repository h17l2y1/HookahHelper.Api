using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookahHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMixAndTobaccoMix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mixes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mixes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TobaccoMixes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TobaccoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    MixId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TobaccoMixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TobaccoMixes_Mixes_MixId",
                        column: x => x.MixId,
                        principalTable: "Mixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TobaccoMixes_MixId",
                table: "TobaccoMixes",
                column: "MixId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TobaccoMixes");

            migrationBuilder.DropTable(
                name: "Mixes");
        }
    }
}
