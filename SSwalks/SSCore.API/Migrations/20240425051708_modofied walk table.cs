using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSCore.API.Migrations
{
    /// <inheritdoc />
    public partial class modofiedwalktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficulty_walkDiffucultyId",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "WalkDificultyId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "walkDiffucultyId",
                table: "Walks",
                newName: "WalkDifficultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_walkDiffucultyId",
                table: "Walks",
                newName: "IX_Walks_WalkDifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficulty_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "WalkDifficulty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficulty_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "WalkDifficultyId",
                table: "Walks",
                newName: "walkDiffucultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks",
                newName: "IX_Walks_walkDiffucultyId");

            migrationBuilder.AddColumn<Guid>(
                name: "WalkDificultyId",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficulty_walkDiffucultyId",
                table: "Walks",
                column: "walkDiffucultyId",
                principalTable: "WalkDifficulty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
