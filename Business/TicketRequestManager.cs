using Microsoft.EntityFrameworkCore;
using TicketManagement.Model;
using TicketManagement.Repository;

namespace TicketManagement.Business
{
    public class TicketRequestManager : ITicketRequestManager
    {
        private readonly AppDbContext _appDbContext;
        public TicketRequestManager(AppDbContext db)
        {
                _appDbContext = db;
        }

        public TicketRequest AddTicketRequest(TicketRequest ticketRequest)
        {
            _appDbContext.ticketRequests.Add(new TicketRequest
            {
                categoryId = ticketRequest.categoryId,
                createdOn = ticketRequest.createdOn,
                description = ticketRequest.description,
                subCategoryId = ticketRequest.subCategoryId
            });
            var id = _appDbContext.Set<TicketRequest>("GetTicketId").ToList().FirstOrDefault();
            foreach(var note in ticketRequest.Notes)
            {
                if(note != null)
                {
                    _appDbContext.notes.Add(new Note
                    {
                        NoteDescription = note.NoteDescription,
                        ticketId = Convert.ToInt32(id)
                    });
                }
            }

            _appDbContext.SaveChanges();
            return ticketRequest;
        }

        public List<TicketRequest> GetAllTicketRequests()
        {
            var ticketRequests = _appDbContext.ticketRequests.ToList();
            return ticketRequests;
        }

        public TicketRequest GetTicketRequest(int ticketId)
        {
            var ticketRequest = _appDbContext.ticketRequests.FirstOrDefault(tr => tr.ticketId == ticketId);
            if(ticketRequest == null)
                throw new Exception("No matching record");
            return ticketRequest;
        }

        public TicketRequest GetTicketRequest(DateTime dt)
        {
            var ticketRequest = _appDbContext.ticketRequests.FirstOrDefault(tr => tr.createdOn == dt);
            if (ticketRequest == null)
                throw new Exception("No matching record");
            return ticketRequest;
        }

        public TicketRequest UpdateTicketRequest(TicketRequest ticketRequest)
        {
            _appDbContext.ticketRequests.Update(ticketRequest);
            _appDbContext.SaveChanges();
            return ticketRequest;
        }
    }
}
