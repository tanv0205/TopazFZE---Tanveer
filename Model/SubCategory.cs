using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Model
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = "";
        public int CategoryId { get; set; }
    }
}
