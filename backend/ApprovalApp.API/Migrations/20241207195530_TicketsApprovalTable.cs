using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApprovalApp.API.Migrations
{
    /// <inheritdoc />
    public partial class TicketsApprovalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketsApprovals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TicketId = table.Column<long>(type: "INTEGER", nullable: false),
                    ApprovingPersonId = table.Column<long>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Новая"),
                    Iteration = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberQueue = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsApprovals_Persons_ApprovingPersonId",
                        column: x => x.ApprovingPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketsApprovals_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketsApprovals_ApprovingPersonId",
                table: "TicketsApprovals",
                column: "ApprovingPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsApprovals_TicketId",
                table: "TicketsApprovals",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsApprovals");
        }
    }
}
