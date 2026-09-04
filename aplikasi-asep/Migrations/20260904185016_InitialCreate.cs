using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aplikasi_asep.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanningRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningDayRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalValue = table.Column<int>(type: "int", nullable: false),
                    ResultValue = table.Column<int>(type: "int", nullable: false),
                    PlanningRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningDayRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningDayRecords_PlanningRecords_PlanningRecordId",
                        column: x => x.PlanningRecordId,
                        principalTable: "PlanningRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningDayRecords_PlanningRecordId",
                table: "PlanningDayRecords",
                column: "PlanningRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningDayRecords");

            migrationBuilder.DropTable(
                name: "PlanningRecords");
        }
    }
}
