using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagement.Migrations
{
    public partial class GetTicketIdProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string getTicketId = @"create procedure GetTicketId
                                as
                                begin
	                                select top 1 ticketId from ticketRequests TR order by ticketId desc;
                                end";
            migrationBuilder.Sql(getTicketId);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string getTicketId = @"drop procedure GetTicketId";
            migrationBuilder.Sql(getTicketId);
        }
    }
}