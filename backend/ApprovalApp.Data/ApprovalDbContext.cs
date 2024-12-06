using ApprovalApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApprovalApp.Data
{
    public class ApprovalDbContext : DbContext
    {
        public ApprovalDbContext(DbContextOptions<ApprovalDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
