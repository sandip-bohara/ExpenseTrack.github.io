using Microsoft.EntityFrameworkCore;

namespace ExpenseTrack.Models
{
    public class ExpenseDbContext : DbContext
    {
        public DbSet<ExpenseData> ExpenseData { get; set; }

        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        { 
            
        }

    }
}
