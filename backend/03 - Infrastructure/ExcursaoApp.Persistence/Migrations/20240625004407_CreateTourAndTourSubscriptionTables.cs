using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcursaoApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateTourAndTourSubscriptionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeadlineUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubscriptionLimit = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsAreFinished = table.Column<bool>(type: "bit", nullable: false),
                    TourDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vehicle = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToursSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionNumber = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToursSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToursSubscriptions_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToursSubscriptions_Users_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_OrganizerId",
                table: "Tours",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_ToursSubscriptions_TourId",
                table: "ToursSubscriptions",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_ToursSubscriptions_TravelerId",
                table: "ToursSubscriptions",
                column: "TravelerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToursSubscriptions");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
