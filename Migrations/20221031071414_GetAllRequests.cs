using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagement.Migrations
{
    public partial class GetAllRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string getAllRequests = @"create procedure GetAllRequests
                                as
                                begin
	                                select *from ticketRequests TR inner join notes N on TR.ticketId = N.ticketId;
                                end";
            migrationBuilder.Sql(getAllRequests);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string getAllRequests = @"drop procedure GetAllRequests";
            migrationBuilder.Sql(getAllRequests);
        }
    }
}
