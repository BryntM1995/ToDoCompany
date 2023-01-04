using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using ToDoCompany.Model.Entities;

namespace ToDoCompany.Model.Context
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<EmployeeTask> Employee { get; set; }
        public DbSet<EmployeeTask> EmployeeTask { get; set; }
        public CompanyDbContext(DbContextOptions options) : base(options)
        {
        }
        public CompanyDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany<EmployeeTask>()
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
