using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalContactInformation.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Telefonnummer",
                table: "People",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefonnummer",
                table: "People",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
