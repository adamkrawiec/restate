using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restate.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToRealEstateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_Name",
                table: "RealEstates",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RealEstates_Name",
                table: "RealEstates");
        }
    }
}
