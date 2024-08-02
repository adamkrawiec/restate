using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restate.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccesses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RealEstateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccesses", x => new { x.UserId, x.RealEstateId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccesses");
        }
    }
}
