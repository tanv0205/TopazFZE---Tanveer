using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public List<SubCategory> SubCategories { get; set; } = new List<SubCategory> { };
    }
}
