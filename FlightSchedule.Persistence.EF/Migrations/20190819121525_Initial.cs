using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightSchedule.Persistence.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharterSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Airline = table.Column<string>(nullable: true),
                    Airplane = table.Column<string>(nullable: true),
                    FlightNo = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharterSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharterTimeTables",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Depart = table.Column<DateTime>(nullable: false),
                    Arrive = table.Column<DateTime>(nullable: false),
                    CharterScheduleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharterTimeTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharterTimeTables_CharterSchedules_CharterScheduleId",
                        column: x => x.CharterScheduleId,
                        principalTable: "CharterSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharterTimeTables_CharterScheduleId",
                table: "CharterTimeTables",
                column: "CharterScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharterTimeTables");

            migrationBuilder.DropTable(
                name: "CharterSchedules");
        }
    }
}
