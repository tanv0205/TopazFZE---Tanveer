using TicketManagement.Model;

namespace TicketManagement.Business
{
    public interface ITicketRequestManager
    {
        List<TicketRequest> GetAllTicketRequests();
        TicketRequest GetTicketRequest(int ticketId);
        TicketRequest GetTicketRequest(DateTime dt);
        TicketRequest AddTicketRequest(TicketRequest ticketRequest);
        TicketRequest UpdateTicketRequest(TicketRequest ticketRequest);
    }
}
