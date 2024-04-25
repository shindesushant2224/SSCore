using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SSCore.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataintoWalkDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WalkDifficulty",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("6638981e-3977-40a1-9dd2-89ee1b466c49"), "Hard" },
                    { new Guid("8cdd93fb-b116-41f5-91a3-5fd973a56023"), "Medium" },
                    { new Guid("d503b6e0-64ff-49a3-9dab-8843378eb74c"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WalkDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("6638981e-3977-40a1-9dd2-89ee1b466c49"));

            migrationBuilder.DeleteData(
                table: "WalkDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("8cdd93fb-b116-41f5-91a3-5fd973a56023"));

            migrationBuilder.DeleteData(
                table: "WalkDifficulty",
                keyColumn: "Id",
                keyValue: new Guid("d503b6e0-64ff-49a3-9dab-8843378eb74c"));
        }
    }
}
