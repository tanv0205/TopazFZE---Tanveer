using Microsoft.EntityFrameworkCore;
using TicketManagement.Model;

namespace TicketManagement.Repository
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<TicketRequest> ticketRequests { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> subcategories { get; set; }
        public DbSet<Note> notes { get; set; }
    }
}
