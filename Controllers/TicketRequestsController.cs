using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Business;
using TicketManagement.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketRequestsController : ControllerBase
    {
        private readonly ITicketRequestManager _ticketRequestManager;
        public TicketRequestsController(ITicketRequestManager ticketRequestManager)
        {
            _ticketRequestManager = ticketRequestManager;
        }
        // GET: api/<TicketRequestsController>
        [HttpGet]
        public IEnumerable<TicketRequest> Get()
        {
            return _ticketRequestManager.GetAllTicketRequests();
        }

        // GET api/<TicketRequestsController>/5
        [HttpGet("{id}")]
        public TicketRequest Get(int id)
        {
            return _ticketRequestManager.GetTicketRequest(id);
        }

        // POST api/<TicketRequestsController>
        [HttpPost]
        public TicketRequest Post([FromBody] TicketRequest ticket)
        {
            _ticketRequestManager.AddTicketRequest(ticket);
            return ticket;
        }

        // PUT api/<TicketRequestsController>/5
        [HttpPut("{id}")]
        public TicketRequest Put(int id, [FromBody] TicketRequest ticket)
        {
            _ticketRequestManager.AddTicketRequest(ticket);
            return ticket;
        }

        // DELETE api/<TicketRequestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
