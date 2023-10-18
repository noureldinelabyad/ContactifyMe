﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalContactInformation.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "People");
        }
    }
}
