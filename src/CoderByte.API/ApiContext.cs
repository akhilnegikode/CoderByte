using CoderByte.API.Mappings;
using CoderByte.API.Model;
using Microsoft.EntityFrameworkCore;

namespace CoderByte.API
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
        }
    }
}
