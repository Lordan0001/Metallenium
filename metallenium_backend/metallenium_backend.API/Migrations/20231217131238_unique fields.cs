using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace metallenium_backend.API.Migrations
{
    public partial class uniquefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmedTickets_TicketId",
                table: "ConfirmedTickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedTickets_TicketId",
                table: "ConfirmedTickets",
                column: "TicketId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmedTickets_TicketId",
                table: "ConfirmedTickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmedTickets_TicketId",
                table: "ConfirmedTickets",
                column: "TicketId");
        }
    }
}
