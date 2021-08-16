using System.Data.Entity;
using WebApiSelfHostBC.Models;
using WebApiSelfHostBC.Seed;

namespace WebApiSelfHostBC.Context
{
    public class Context : DbContext
    {
       public Context(string location = "localdb") : base(location)
        {
            Database.SetInitializer<Context>(new DbInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Employee>()
                .HasIndex(e => new { e.FirstName, e.LastName });
    
            modelBuilder.Entity<Employee>()
                .HasRequired<Company>(c => c.Company)
                .WithMany(e => e.Employees)
                .HasForeignKey<long>(c => c.CompanyId);
        }
        public DbSet<Employee>   Employees { get; set; }
        public DbSet<Company>   Companys { get; set; }
    }
}
