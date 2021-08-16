using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions<Context> opts)
             : base(opts) { }

        public DbSet<Employee>   Employees { get; set; }
        public DbSet<Company>   Companys { get; set; }
    }
}
