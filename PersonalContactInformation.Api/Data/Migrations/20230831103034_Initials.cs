using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalContactInformation.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zwischenname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<int>(type: "int", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straße = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hausnummer = table.Column<int>(type: "int", nullable: false),
                    PLZ = table.Column<int>(type: "int", nullable: false),
                    Stadt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
