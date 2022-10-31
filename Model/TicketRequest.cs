using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Model
{
    public class TicketRequest
    {
        [Key]
        public int ticketId { get; set; }
        public DateTime createdOn { get; set; }
        public int categoryId { get; set; }
        public int subCategoryId { get; set; }
        public string description { get; set; } = "";
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
