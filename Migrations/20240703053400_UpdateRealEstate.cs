using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restate.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealEstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "RealEstates",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "RealEstates",
                newName: "HouseNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "RealEstates",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "RealEstates",
                newName: "Number");
        }
    }
}
