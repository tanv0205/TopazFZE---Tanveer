using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Model
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public string NoteDescription { get; set; } = string.Empty;
        public int ticketId { get; set; }
    }
}
