using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    middleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    experience = table.Column<byte>(type: "smallint", maxLength: 60, nullable: false),
                    requisites = table.Column<string>(type: "jsonb", nullable: true),
                    socials = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_volunteers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    species = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    color = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    healthInfo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    weight = table.Column<int>(type: "integer", maxLength: 120, nullable: false),
                    height = table.Column<int>(type: "integer", maxLength: 250, nullable: false),
                    phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    isNeutered = table.Column<bool>(type: "boolean", nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isVaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    helpStatus = table.Column<int>(type: "integer", nullable: false),
                    dateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    volunteerId = table.Column<Guid>(type: "uuid", nullable: false),
                    photos = table.Column<string>(type: "jsonb", nullable: true),
                    requisites = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_pets", x => x.id);
                    table.ForeignKey(
                        name: "fK_pets_volunteers_volunteerId",
                        column: x => x.volunteerId,
                        principalTable: "volunteers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "iX_pets_volunteerId",
                table: "pets",
                column: "volunteerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "volunteers");
        }
    }
}
